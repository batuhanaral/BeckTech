using BeckTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BechTech.Entity.Entities
{
    public class Category : EntityBase 
    {
        public Category()
        {
            
        }
        public Category(string name,string createdBy)
        {
            Name = name; 
            CreatedBy = createdBy;
        }
        public string Name  { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
