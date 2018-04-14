using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Oncology.Model
{    
    public class Patient : IIdentity<Patient>
    {
        [Key]        
        public int Id { get; set; }

        [StringLength(13)]
        public string CNP { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public IList<Diagnostic> Diagnostics { get; set; }

        public void UpdatePropertiesFrom(Patient that)
        {
            throw new NotImplementedException();
        }
    }
}