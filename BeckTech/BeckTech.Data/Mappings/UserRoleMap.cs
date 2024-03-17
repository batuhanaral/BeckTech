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
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");
            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("0B66F151-E4AB-4A80-B867-6B868CF2E400"),
                RoleId = Guid.Parse("94B70614-D607-4883-8205-442444A54710")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("0B66F151-E4AB-4A80-B867-6B868CF2E401"),
                RoleId = Guid.Parse("94B70614-D607-4883-8205-442444A54711")
            }
            );
        }
    }
}
