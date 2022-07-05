using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ITI.Sauce.Models
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendor");
            builder.HasKey(v => v.ID);
            builder.Property(v => v.UserName).HasMaxLength(500).IsRequired();
            builder.Property(v => v.Password).HasMaxLength(50).IsRequired();
            builder.Property(v => v.Email).HasMaxLength(50).IsRequired();
            builder.Property(v => v.phone).HasMaxLength(50).IsRequired();
            builder.Property(v => v.NameEN).HasMaxLength(500).IsRequired();
            builder.Property(v => v.NameAR).HasMaxLength(500).IsRequired();
            builder.Property(v => v.registerDate).HasDefaultValue(DateTime.Now);
            builder.Property(v => v.IsDeleted).HasDefaultValue(false);



        }
    }
}
