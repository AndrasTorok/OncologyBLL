using System;
using System.Collections.Generic;

namespace OncologyCore.Model;

public partial class Cycle
{
    public int Id { get; set; }

    public int DiagnosticId { get; set; }

    public DateTime StartDate { get; set; }

    public int TreatmentId { get; set; }

    public double? SerumCreat { get; set; }

    public int Height { get; set; }

    public int Weight { get; set; }

    public bool Emitted { get; set; }

    public virtual ICollection<CycleItem> CycleItems { get; set; } = new List<CycleItem>();

    public virtual Diagnostic Diagnostic { get; set; } = null!;

    public virtual Treatment Treatment { get; set; } = null!;
}
