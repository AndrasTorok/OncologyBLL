using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OncologyCore.Model;

namespace OncologyReceipts.Api
{
    [Route("api/diagnostic")]
    public class DiagnosticController : ApiBaseController<Diagnostic>
    {
        public DiagnosticController(OncologyReceiptsContext context) : base(context)
        {

        }

        [Route("getAllForPatientId/{patientId:int}"), HttpGet]        
        public async Task<IList<Diagnostic>> GetAllForPatientId(int patientId)
        {
            List<Diagnostic> diagnostics = await context.Diagnostics.Where(d => d.PatientId == patientId).ToListAsync();

            return diagnostics;
        }

        [Route("{id}"), HttpDelete]
        public override async Task<IActionResult> Delete(int id)
        {
            if (await context.Diagnostics.AnyAsync(diagnostic => diagnostic.Id == id && diagnostic.Cycles.Any()))
            {
                string message = $"Diagnostic-ul nu se poate sterge pentru ca are deja cicluri de tratament.";

                return StatusCode(StatusCodes.Status403Forbidden, message);                
            } 

            return await base.Delete(id);
        }
    }
}