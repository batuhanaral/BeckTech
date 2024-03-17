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
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder) 
        {
            builder.HasData(new Image
            {


                Id = Guid.Parse("006B8234-53E7-4482-A70D-B36C12304432"),
                FileName = "images/testimage",
                FileType = "jpg",
                CreatedDate = DateTime.Now,
                CreatedBy = "Test Admin",
                IsDeleted = false




            },
            new Image
            {
                Id = Guid.Parse("E800C003-F241-43D9-8A75-0713987357F6"),
                FileName = "images/testimage",
                FileType = "jpg",
                CreatedDate = DateTime.Now,
                CreatedBy = "Test Admin",
                IsDeleted = false

            }


            );
        }
    }
}
