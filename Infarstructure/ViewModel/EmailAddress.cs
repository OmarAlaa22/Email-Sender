using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstructure.ViewModel
{
   public class EmailAddress
    {
       public string Email { get; set; }
        [Required]
        public int SubjectMailId { get; set; }


    }
}
