using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oncology.Model
{
    public class Cycle : IIdentity
    {
        [Key]
        public int Id { get; set; }

        public int DiagnosticId { get; set; }

        [ForeignKey("DiagnosticId")]
        public virtual Diagnostic Diagnostic { get; set; }

        public DateTime StartDate { get; set; }

        public int TreatmentId { get; set; }

        [ForeignKey("TreatmentId")]
        public virtual Treatment Treatment { get; set; }

        public IList<CycleItem> CycleItems { get; set; }

        public override bool Equals(object obj)
        {
            Cycle that = obj as Cycle;

            return that != null && that.Id == Id && that.DiagnosticId == DiagnosticId && that.StartDate == StartDate && that.TreatmentId == TreatmentId;
        }

        public override string ToString()
        {
            return $"{Id} - {DiagnosticId} - {TreatmentId} {StartDate}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public void UpdateFromPropertiesFrom(Cycle that)
        {
            this.DiagnosticId = that.DiagnosticId;
            //this.Diagnostic = that.Diagnostic;
            this.StartDate = that.StartDate;
            this.TreatmentId = that.TreatmentId;
            //this.Treatment = that.Treatment;            
        }
    }
}
