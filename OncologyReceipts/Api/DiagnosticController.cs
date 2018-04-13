using Oncology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using System.Data.Entity;

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
    }
}