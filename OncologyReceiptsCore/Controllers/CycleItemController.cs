using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OncologyCore.Model;

namespace OncologyReceipts.Api
{
    [Route("api/cycleItem")]
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