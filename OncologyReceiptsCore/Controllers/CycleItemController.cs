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

        [Route("{id}"), HttpGet]
        public override async Task<CycleItem> GetById(int id)
        {
            CycleItem cycleItem = await context.CycleItems.Include(ci=> ci.TreatmentItem).ThenInclude(ti => ti.Medicament).FirstOrDefaultAsync(p => p.Id == id);

            return cycleItem;
        }    
    }
}