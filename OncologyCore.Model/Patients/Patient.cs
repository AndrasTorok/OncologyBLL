using System;
using System.Collections.Generic;

namespace OncologyCore.Model;

public partial class Patient
{
    public int Id { get; set; }

    public string? CNP { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int Gender { get; set; }

    public DateTime BirthDate { get; set; }

    public int Height { get; set; }

    public int Weight { get; set; }

    public virtual ICollection<Diagnostic> Diagnostics { get; set; } = new List<Diagnostic>();
}
