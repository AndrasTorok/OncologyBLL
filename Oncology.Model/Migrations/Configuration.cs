namespace Oncology.Model.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Oncology.Model.OncologyReceiptsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Oncology.Model.OncologyReceiptsContext context)
        {
            SeedingHelper seedingHelper = new SeedingHelper(context);

            seedingHelper.Seed();

            base.Seed(context);
        }
    }
}
