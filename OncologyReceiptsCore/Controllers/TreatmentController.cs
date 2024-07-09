using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OncologyCore.Model;

namespace OncologyReceipts.Api
{
    [Route("api/treatement")]
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