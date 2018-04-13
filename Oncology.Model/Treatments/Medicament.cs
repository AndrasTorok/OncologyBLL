using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oncology.Model
{
    public class Medicament : IIdentity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public DoseApplicationMode DoseApplicationMode { get; set; }

        public double Dose { get; set; }
    }
}
