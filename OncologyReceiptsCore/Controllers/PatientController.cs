using OncologyCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace OncologyReceipts.Api
{
    [Route("api/patient")]
    public class PatientController : ApiBaseController<Patient>
    {
        public PatientController(OncologyReceiptsContext context) : base(context)
        {

        }

        [Route("{id}"), HttpGet]
        public override async Task<Patient> GetById(int id)
        {
            Patient patient = await context.Patients.Include(p => p.Diagnostics).FirstOrDefaultAsync(p => p.Id == id);

            return patient;
        }

        [Route("{id}"), HttpDelete]
        public override async Task<IActionResult> Delete(int id)
        {
            if (await context.Patients.AnyAsync(patient => patient.Id == id && patient.Diagnostics.Any()))
            {
                string message = $"Patient-ul nu se poate sterge pentru care are deja diagnostic.";

                return StatusCode(StatusCodes.Status403Forbidden, message);
            }

            return await base.Delete(id);
        }
    }
}
