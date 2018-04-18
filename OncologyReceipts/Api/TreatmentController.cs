using Oncology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OncologyReceipts.Api
{
    public class TreatmentController : ApiBaseController<Treatment>
    {
        public TreatmentController(OncologyReceiptsContext context) : base(context)
        {

        }        

        public override async Task<Treatment> GetById(int id)
        {
            Treatment treatment = await context.Treatments.Include(t=>t.TreatmentItems).Include(t => t.TreatmentItems.Select(i=>i.Medicament)).FirstOrDefaultAsync(p => p.Id == id);

            return treatment;
        }    
    }
}