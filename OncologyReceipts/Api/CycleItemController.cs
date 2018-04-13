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
    public class CycleItemController : ApiBaseController<CycleItem>
    {
        public CycleItemController(OncologyReceiptsContext context) : base(context)
        {

        }         

        public override async Task<CycleItem> GetById(int id)
        {
            CycleItem cycleItem = await context.CycleItems.Include(ci=> ci.TreatmentItem).Include(ci => ci.TreatmentItem.Medicament).FirstOrDefaultAsync(p => p.Id == id);

            return cycleItem;
        }    
    }
}