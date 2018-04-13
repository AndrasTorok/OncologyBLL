using Oncology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Http;

namespace OncologyReceipts.Api
{
    [RoutePrefix("api/cycle")]
    public class CycleController : ApiBaseController<Cycle>
    {
        public CycleController(OncologyReceiptsContext context) : base(context)
        {

        }         

        public override async Task<Cycle> GetById(int id)
        {
            Cycle cycle = await context.Cycles.Include(c => c.Treatment).Include(c => c.CycleItems).FirstOrDefaultAsync(p => p.Id == id);

            return cycle;
        }    

        [Route("getAllForDiagnosticId/{diagnosticId:int}")]
        [HttpGet]
        public async Task<IList<Cycle>> GetAllForDiagnosticId(int diagnosticId)
        {
            List<Cycle> cycles = await context.Cycles.Include(c => c.Treatment).Where(c => c.DiagnosticId == diagnosticId).ToListAsync();

            return cycles;
        }

        [Route("cycleGraph")]
        [HttpPost]
        public async Task<Cycle> CycleGraph(Cycle cycle)
        {
            try
            {
                if (cycle != null)
                {
                    if (cycle.Id != 0)                      //updating cycle
                    {
                        Cycle storeCycle = await context.Cycles.Include(context => context.CycleItems).FirstOrDefaultAsync(c => c.Id == cycle.Id);
                        List<CycleItem> cycleItems = cycle.CycleItems.ToList(),
                            storeCycleItems = storeCycle.CycleItems.ToList();

                        if (!storeCycle.Equals(cycle))
                        {
                            storeCycle.UpdateFromPropertiesFrom(cycle);
                        }

                        var collectionChanges = CollectionChangeDetector<CycleItem>.CollectionChanges(cycleItems, storeCycleItems);

                        collectionChanges.Added.ForEach(entity =>
                        {
                            storeCycle.CycleItems.Add(entity);
                        });

                        collectionChanges.Deleted.ForEach(entity =>
                        {
                            CycleItem storeCycleItem = storeCycleItems.First(sci => sci.Id == entity.Id);

                            context.CycleItems.Remove(storeCycleItem);
                        });

                        collectionChanges.Updated.ForEach(entity =>
                        {
                            CycleItem storeCycleItem = storeCycleItems.First(sci => sci.Id == entity.Id);

                            storeCycleItem.UpdateFromPropertiesFrom(entity);
                        });
                    }
                    else
                    {                                       //adding cycle
                        context.Cycles.Add(cycle);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                cycle = null;
            }

            return cycle;
        }        
    }
}