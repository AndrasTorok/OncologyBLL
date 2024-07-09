using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OncologyCore.Model;

namespace OncologyReceipts.Api
{
    [Route("api/treatment")]
    public class TreatmentController : ApiBaseController<Treatment>
    {
        public TreatmentController(OncologyReceiptsContext context) : base(context)
        {

        }

        [Route("{id}"), HttpGet]
        public override async Task<Treatment> GetById(int id)
        {
            Treatment treatment = await context.Treatments.Include(t => t.TreatmentItems).ThenInclude(tii => tii.Medicament).FirstOrDefaultAsync(p => p.Id == id);

            return treatment;
        }
    }
}