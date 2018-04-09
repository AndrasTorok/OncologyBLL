using Oncology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OncologyReceipts.Api
{
    public class DiagnosticController : ApiBaseController<Diagnostic>
    {
        public DiagnosticController(OncologyReceiptsContext context) : base(context)
        {

        }                     
    }
}