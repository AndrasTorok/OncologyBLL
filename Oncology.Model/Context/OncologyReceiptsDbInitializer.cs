using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oncology.Model
{
    public class OncologyReceiptsDbInitializer : DropCreateDatabaseAlways<OncologyReceiptsContext>
    {
        protected override void Seed(OncologyReceiptsContext context)
        {
            SeedingHelper seedingHelper = new SeedingHelper(context);

            seedingHelper.Seed();

            base.Seed(context);
        }
    }
}
