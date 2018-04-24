using Oncology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net.Http;
using System.Net;

namespace OncologyReceipts.Api
{
    [RoutePrefix("api/diagnostic")]
    public class DiagnosticController : ApiBaseController<Diagnostic>
    {
        public DiagnosticController(OncologyReceiptsContext context) : base(context)
        {

        }

        [Route("getAllForPatientId/{patientId:int}")]
        [HttpGet]
        public async Task<IList<Diagnostic>> GetAllForPatientId(int patientId)
        {
            List<Diagnostic> diagnostics = await context.Diagnostics.Where(d => d.PatientId == patientId).ToListAsync();

            return diagnostics;
        }

        public override async Task<HttpResponseMessage> Delete(int id)
        {
            if (await context.Diagnostics.AnyAsync(diagnostic => diagnostic.Id == id && diagnostic.Cycles.Any()))
            {
                string message = $"Diagnostic-ul nu se poate sterge pentru ca are deja cicluri de tratament.";

                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, message);
            } 

            return await base.Delete(id);
        }
    }
}