﻿using Oncology.Model;
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

        public override async Task<HttpResponseMessage> Delete(int id)
        {
            if (await context.Patients.AnyAsync(patient => patient.Id == id && patient.Diagnostics.Any()))
            {
                string message = $"Patient-ul nu se poate sterge pentru care are deja diagnostic.";

                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, message);
            }

            return await base.Delete(id);
        }
    }
}
