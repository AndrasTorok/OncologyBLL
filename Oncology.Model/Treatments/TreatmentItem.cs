using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oncology.Model
{
    public class TreatmentItem : IIdentity<TreatmentItem>
    {
        [Key]
        public int Id { get; set; }

        public int TreatmentId { get; set; }

        [ForeignKey("TreatmentId")]
        public virtual Treatment Treatment { get; set; }
        
        public int MedicamentId { get; set; }

        [ForeignKey("MedicamentId")]
        public virtual Medicament Medicament { get; set; }

        public int OnDay { get; set; }

        public void UpdatePropertiesFrom(TreatmentItem that)
        {
            throw new NotImplementedException();
        }
    }
}
