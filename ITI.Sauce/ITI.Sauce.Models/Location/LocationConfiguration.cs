using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Sauce.Models
{
    class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location");
            builder.HasKey(l => new { l.Restaurant_ID, l.Location_Name });
            builder.Property(l => l.Restaurant_ID).IsRequired();
            builder.Property(l => l.Location_Name).IsRequired().HasMaxLength(300);
            builder.Property(l => l.LocationEN).IsRequired().HasMaxLength(300);
            builder.Property(l => l.LocationAR).IsRequired().HasMaxLength(300);


        }
    }
}
