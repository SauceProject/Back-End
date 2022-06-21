using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Sauce.Models
{
    public class Restaurant_PhonesConfiguration : IEntityTypeConfiguration<Restaurant_Phones>
    {
        public void Configure(EntityTypeBuilder<Restaurant_Phones> builder)
        {
            builder.ToTable("Restaurant_Phones");
            builder.HasKey(rp => new { rp.Restaurant_ID, rp.Restaurant_phone });
            builder.Property(rp => rp.Restaurant_ID);
            builder.Property(rp => rp.Restaurant_phone);
        }
    }
}
