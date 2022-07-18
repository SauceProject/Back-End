using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;



namespace ITI.Sauce.Models
{
   public static class DataRole
    {
        public static void RoleData(this ModelBuilder builder)
        {
           builder.Entity<IdentityRole>().HasData(
                new IdentityRole {Id= "1", Name = "Admin",NormalizedName="ADMIN" },
                new IdentityRole { Id = "2", Name = "Vendor",NormalizedName="VENDOR" },
                new IdentityRole{ Id = "3", Name = "User" , NormalizedName ="USER"}
                );
        }
    }

   
}
