using Oncology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace OncologyReceipts.Api
{
    public class PatientController : ApiBaseController<Patient>
    {
        public PatientController(OncologyReceiptsContext context) : base(context)
        {

        }

        public override async Task<Patient> GetById(int id)
        {
            Patient patient = await context.Patients.Include(p => p.Diagnostics).FirstOrDefaultAsync(p => p.Id == id);

            return patient;
        }
    }
}
