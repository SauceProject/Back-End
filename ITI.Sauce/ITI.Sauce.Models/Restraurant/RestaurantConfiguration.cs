using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Sauce.Models
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurant");
            builder.HasKey(r => r.ID);
            builder.Property(r => r.ID).ValueGeneratedOnAdd();
            builder.Property(r => r.WorkTime).IsRequired();
            builder.Property(r => r.Vendor_ID).IsRequired();
            builder.Property(r => r.NameEN).IsRequired().HasMaxLength(300);
            builder.Property(r => r.NameAR).IsRequired().HasMaxLength(300);
            builder.Property(r => r.ImageUrl).IsRequired().HasMaxLength(300);
            builder.Property(r => r.RegisterDate).HasDefaultValue(DateTime.Now);
            builder.Property(r => r.IsDeleted).HasDefaultValue(false);



        }
    }
}
