using System;
using System.Collections.Generic;

namespace OncologyCore.Model;

public partial class TreatmentItem
{
    public int Id { get; set; }

    public int TreatmentId { get; set; }

    public int MedicamentId { get; set; }

    public int OnDay { get; set; }

    public int? EndDay { get; set; }

    public int? DayStep { get; set; }

    public double Dose { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CycleItem> CycleItems { get; set; } = new List<CycleItem>();

    public virtual Medicament Medicament { get; set; } = null!;

    public virtual Treatment Treatment { get; set; } = null!;
}
