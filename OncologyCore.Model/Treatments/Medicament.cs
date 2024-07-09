using System;
using System.Collections.Generic;

namespace OncologyCore.Model;

public partial class Medicament
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int DoseApplicationMode { get; set; }

    public virtual ICollection<CycleItem> CycleItems { get; set; } = new List<CycleItem>();

    public virtual ICollection<TreatmentItem> TreatmentItems { get; set; } = new List<TreatmentItem>();
}
