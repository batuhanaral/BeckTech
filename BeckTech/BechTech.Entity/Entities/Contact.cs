using BeckTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BechTech.Entity.Entities
{
    public class Contact : EntityBase
    {
        public Contact()
        {

        }
        public Contact(string nameSurname, string email, string subject, string message)
        {
            NameSurname = nameSurname;
            Email = email;
            Subject = subject;
            Message = subject;
          

        }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }

      




      

    }
}
