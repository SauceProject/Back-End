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
            builder.HasKey(u => u.Id);
            builder.Property(U => U.NameEN).HasMaxLength(200).IsRequired();
            builder.Property(U => U.NameAR).HasMaxLength(200).IsRequired();
            builder.Property(U => U.registerDate).HasDefaultValue(DateTime.Now);
            builder.Property(U => U.IsDelete).HasDefaultValue(false);




        }
    }
}
