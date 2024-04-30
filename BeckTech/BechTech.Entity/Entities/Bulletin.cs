using BeckTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BechTech.Entity.Entities
{
    public class Bulletin :EntityBase
    {
        public Bulletin()
        {

        }
        public Bulletin(string email)
        {

            Email = email;

        }
        public string Email { get; set; }
    }
}
