using OncologyCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace OncologyReceipts.Api
{
    [Route("api/treatmentItem")]
    public class TreatmentItemController : ApiBaseController<TreatmentItem>
    {
        public TreatmentItemController(OncologyReceiptsContext context) : base(context)
        {

        }

        [Route("{id}"), HttpGet]
        public override async Task<TreatmentItem> GetById(int id)
        {
            TreatmentItem treatmentItem = await context.TreatmentItems.Include(ti=>ti.Medicament).FirstOrDefaultAsync(p => p.Id == id);

            return treatmentItem;
        }    
    }
}