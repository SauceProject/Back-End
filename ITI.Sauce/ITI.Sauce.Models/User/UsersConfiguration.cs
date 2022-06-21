using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Sauce.Models
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(U => U.ID);
            builder.Property(U => U.ID).ValueGeneratedOnAdd();
            builder.Property(U => U.UserName).HasMaxLength(200).IsRequired();
            builder.Property(U => U.Password).HasMaxLength(200).IsRequired();
            builder.Property(U => U.Email).HasMaxLength(200).IsRequired();
            builder.Property(U => U.phone).HasMaxLength(20).IsRequired();
            builder.Property(U => U.NameEN).HasMaxLength(200).IsRequired();
            builder.Property(U => U.NameAR).HasMaxLength(200).IsRequired();
            builder.Property(U => U.registerDate).IsRequired();
            builder.Property(U => U.IsDelete).IsRequired();




        }
    }
}
