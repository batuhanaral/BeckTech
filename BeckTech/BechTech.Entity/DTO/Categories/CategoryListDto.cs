using BechTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BechTech.Entity.DTO.Categories
{
    public class CategoryListDto
    {
        public IList<Category> Categories { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual int CurrentPageC { get; set; } = 1;
        public virtual int PageSizeC { get; set; } = 5;
        public virtual int TotalCountC { get; set; }
        public virtual int TotalPagesC => (int)Math.Ceiling(decimal.Divide(TotalCountC, PageSizeC));
        public virtual bool ShowPreviousC => CurrentPageC > 1;
        public virtual bool ShowNextC => CurrentPageC < TotalPagesC;
        public virtual bool IsAscendingC { get; set; } = false;
    }
}
