using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oncology.Model
{
    public class OncologyReceiptsContext : DbContext
    {
        public OncologyReceiptsContext():
            base("name=OncologyReceiptsConnectionString")
        {
            Database.SetInitializer<OncologyReceiptsContext>(new OncologyReceiptsDbInitializer());
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Diagnostic> Diagnostics { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Treatment> Treatments { get; set; }

        public DbSet<TreatmentItem> TreatmentItems { get; set; }

        public DbSet<Cycle> Cycles { get; set; }

        public DbSet<CycleItem> CycleItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cycle>().HasRequired<Treatment>(cycle => cycle.Treatment).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<TreatmentItem>().HasRequired<Medicament>(ti=>ti.Medicament).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<TreatmentItem>().HasRequired<Treatment>(ti => ti.Treatment).WithMany().WillCascadeOnDelete(false);
        }
    }
}
