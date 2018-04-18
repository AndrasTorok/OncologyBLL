using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oncology.Model
{
    public class Treatment : IIdentity<Treatment>
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
       
        public bool IsSerumCreatNeeded { get; set; }

        public IList<TreatmentItem> TreatmentItems { get; set; }

        public void UpdatePropertiesFrom(Treatment that)
        {
            throw new NotImplementedException();
        }
    }
}
