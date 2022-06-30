using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Sauce.Models
{
    public class FavConfiguration : IEntityTypeConfiguration<Fav>
    {
        public void Configure(EntityTypeBuilder<Fav> builder)
        {
            builder.ToTable("Fav");
            builder.HasKey(F => F.ID);
            builder.Property(F => F.ID).ValueGeneratedOnAdd();
            builder.Property(F => F.UserID).HasMaxLength(450).IsRequired();
            builder.Property(F => F.Recipe_ID).HasMaxLength(50).IsRequired();


        }
    }
}
