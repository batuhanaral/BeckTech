using BechTech.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = Guid.Parse("006B8234-53E7-4482-A70D-B36C12304431"),
                Name = "C#",
                CreatedBy = "AdminTest",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Category
            {
                Id = Guid.Parse("E800C003-F241-43D9-8A75-0713987357F5"),
                Name = "Asp.Net",
                CreatedBy = "AdminTest",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });

           








        }
    }
}
