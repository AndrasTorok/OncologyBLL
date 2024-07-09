using System;
using System.Collections.Generic;

namespace OncologyCore.Model;

public partial class Diagnostic
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public string? Description { get; set; }

    public string? Localization { get; set; }

    public DateTime Date { get; set; }

    public virtual ICollection<Cycle> Cycles { get; set; } = new List<Cycle>();

    public virtual Patient Patient { get; set; } = null!;
}
