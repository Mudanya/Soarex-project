using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var passwordHash = new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser
            {
                Id = "95B168FE-810B-432D-9010-233BA0B380E9",
                UserName = "nmudanya94@gmail.com",
                NormalizedUserName = "NMUDANYA94@GMAIL.COM",
                Email = "nmudanya94@gmail.com",
                NormalizedEmail = "NMUDANYA94@GMAIL.COM",
                EmailConfirmed = true,
                FullName = "Nelson Mudanya",
                PhoneNumber = "0700263761",
            };
            user.PasswordHash = passwordHash.HashPassword(user, "@Ndevandeva1");
            builder.HasData(
               user
            );
        }
    }
}
