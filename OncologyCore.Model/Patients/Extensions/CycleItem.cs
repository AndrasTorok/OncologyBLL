namespace OncologyCore.Model
{
    public partial class CycleItem :IIdentity<CycleItem>
    {
        public override bool Equals(object obj)
        {
            CycleItem that = obj as CycleItem;

            return that != null && that.Id == Id && that.CycleId == CycleId && that.TreatmentItemId == TreatmentItemId && that.MedicamentId == MedicamentId &&
                that.OnDay == OnDay && that.QuantityApplied == QuantityApplied && that.QuantityCalculated == that.QuantityCalculated;
        }

        public override string ToString()
        {
            return $"{Id} - {CycleId} - {TreatmentItemId} - {MedicamentId} - {OnDay} , {QuantityCalculated} , {QuantityApplied}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public void UpdatePropertiesFrom(CycleItem that)
        {
            this.CycleId = that.CycleId;
            this.TreatmentItemId = that.TreatmentItemId;
            this.MedicamentId = that.MedicamentId;
            this.OnDay = that.OnDay;
            this.QuantityApplied = that.QuantityApplied;
            this.QuantityCalculated = that.QuantityCalculated;
        }
    }
}
