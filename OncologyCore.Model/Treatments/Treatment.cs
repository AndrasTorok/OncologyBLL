using System;
using System.Collections.Generic;

namespace OncologyCore.Model;

public partial class Treatment
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool IsSerumCreatNeeded { get; set; }

    public bool IsDefault { get; set; }

    public virtual ICollection<Cycle> Cycles { get; set; } = new List<Cycle>();

    public virtual ICollection<TreatmentItem> TreatmentItems { get; set; } = new List<TreatmentItem>();
}
