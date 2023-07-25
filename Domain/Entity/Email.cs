using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public class Email
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        [Required] 
        public string Message { get; set; }


    }
}
