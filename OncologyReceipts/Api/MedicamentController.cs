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
    public class MedicamentController : ApiBaseController<Medicament>
    {
        public MedicamentController(OncologyReceiptsContext context) : base(context)
        {

        }        
    }
}
