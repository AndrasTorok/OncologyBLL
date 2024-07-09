using Microsoft.AspNetCore.Mvc;
using OncologyCore.Model;

namespace OncologyReceipts.Api
{
    [Route("api/medicament")]
    public class MedicamentController : ApiBaseController<Medicament>
    {
        public MedicamentController(OncologyReceiptsContext context) : base(context)
        {

        }        
    }
}
