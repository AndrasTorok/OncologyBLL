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

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<Cycle>().HasRequired<Treatment>(cycle => cycle.Treatment).WithMany().WillCascadeOnDelete(false);      //when deleting Cycle don't delete Treatment

            mb.Entity<CycleItem>().HasRequired<Medicament>(ti => ti.Medicament).WithMany().WillCascadeOnDelete(false);      //when deleting CycleItem don't delete Medicament
            mb.Entity<CycleItem>().HasRequired<TreatmentItem>(ti => ti.TreatmentItem).WithMany().WillCascadeOnDelete(false);    //when deleting CycleItem don't delete TreatmentItem

            mb.Entity<TreatmentItem>().HasRequired<Medicament>(ti=>ti.Medicament).WithMany().WillCascadeOnDelete(false);    //when deleting TreatmentItem don't delete Medicament
        }
    }
}
