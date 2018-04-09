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
    public class TreatmentItemController : ApiBaseController<TreatmentItem>
    {
        public TreatmentItemController(OncologyReceiptsContext context) : base(context)
        {

        }         

        public override async Task<TreatmentItem> GetById(int id)
        {
            TreatmentItem treatmentItem = await context.TreatmentItems.Include(ti=>ti.Medicament).FirstOrDefaultAsync(p => p.Id == id);

            return treatmentItem;
        }    
    }
}