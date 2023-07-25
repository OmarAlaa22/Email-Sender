using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Email_Sender.ViewModel
{
    public class EmailViewModel
    {
        public int Id { get; set; }
        public string subject { get; set; }
        [Required]
        public string message { get; set; }


    }
}
