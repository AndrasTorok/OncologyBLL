namespace OncologyCore.Model
{
    public partial class Cycle : IIdentity<Cycle>
    {
        public override bool Equals(object obj)
        {
            Cycle that = obj as Cycle;

            return that != null && that.Id == Id && that.DiagnosticId == DiagnosticId && that.StartDate == StartDate && that.TreatmentId == TreatmentId
                && that.SerumCreat == SerumCreat && that.Height == Height && that.Weight == Weight;
        }

        public override string ToString()
        {
            return $"{Id} - {DiagnosticId} - {TreatmentId} , {StartDate}, {SerumCreat} , {Height} : {Weight}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public void UpdatePropertiesFrom(Cycle that)
        {
            this.DiagnosticId = that.DiagnosticId;
            this.StartDate = that.StartDate;
            this.TreatmentId = that.TreatmentId;
            this.SerumCreat = that.SerumCreat;
            this.Height = that.Height;
            this.Weight = that.Weight;
        }
    }
}
