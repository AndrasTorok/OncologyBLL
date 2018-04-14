using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oncology.Model
{
    public class Diagnostic : IIdentity<Diagnostic>
    {
        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(200)]
        public string Localization { get; set; }

        public DateTime Date { get; set; }

        public void UpdatePropertiesFrom(Diagnostic that)
        {
            throw new NotImplementedException();
        }
    }
}
