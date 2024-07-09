using System;
using System.Collections.Generic;

namespace OncologyCore.Model;

public partial class CycleItem
{
    public int Id { get; set; }

    public int CycleId { get; set; }

    public int TreatmentItemId { get; set; }

    public int MedicamentId { get; set; }

    public int OnDay { get; set; }

    public double QuantityCalculated { get; set; }

    public double QuantityApplied { get; set; }

    public virtual Cycle Cycle { get; set; } = null!;

    public virtual Medicament Medicament { get; set; } = null!;

    public virtual TreatmentItem TreatmentItem { get; set; } = null!;
}
