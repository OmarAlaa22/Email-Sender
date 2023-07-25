using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstructure.Data
{
   public class EmailSenderDbContex : DbContext
    {
    
        public EmailSenderDbContex(DbContextOptions<EmailSenderDbContex> options):base(options)
        {
                
        }
        public DbSet<Email> Emails { get; set; }

    }
}
