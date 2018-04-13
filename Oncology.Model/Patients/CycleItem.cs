using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oncology.Model
{
    public class CycleItem : IIdentity
    {
        [Key]
        public int Id { get; set; }

        public int CycleId { get; set; }

        [ForeignKey("CycleId")]
        public virtual Cycle Cycle { get; set; }       

        public int TreatmentItemId { get; set; }

        [ForeignKey("TreatmentItemId")]
        public virtual TreatmentItem TreatmentItem { get; set; }

        public int MedicamentId { get; set; }

        [ForeignKey("MedicamentId")]
        public virtual Medicament Medicament { get; set; }

        public int OnDay { get; set; }

        public double QuantityCalculated { get; set; }

        public double QuantityApplied { get; set; }

        public void UpdateFromPropertiesFrom(CycleItem that)
        {
            this.CycleId = that.CycleId;
            this.TreatmentItemId = that.TreatmentItemId;
            //this.TreatmentItem = that.TreatmentItem;
            this.MedicamentId = that.MedicamentId;
            //this.Medicament = that.Medicament;
            this.OnDay = that.OnDay;
            this.QuantityApplied = that.QuantityApplied;
            this.QuantityCalculated = that.QuantityCalculated;
        }

        public override bool Equals(object obj)
        {
            CycleItem that = obj as CycleItem;

            return that != null && that.Id == Id && that.CycleId == CycleId && that.TreatmentItemId == TreatmentItemId && that.MedicamentId == MedicamentId &&
                that.OnDay == OnDay && that.QuantityApplied == QuantityApplied && that.QuantityCalculated == that.QuantityCalculated;
        }

        public override string ToString()
        {
            return $"{Id} - {CycleId} - {TreatmentItemId} - {MedicamentId} - {OnDay} {QuantityCalculated} , {QuantityApplied}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
