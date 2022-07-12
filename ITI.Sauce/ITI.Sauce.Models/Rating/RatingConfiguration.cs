using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Sauce.Models
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Rating");
            builder.HasKey(R=>R.RatingID);
            builder.Property(R => R.RatingID).ValueGeneratedOnAdd();
            builder.Property(R => R.Comment).HasMaxLength(450);
            builder.Property(R => R.RatingValue).IsRequired();
            builder.Property(R => R.RecipeID).IsRequired();
            builder.Property(R => R.UserID).IsRequired();
            builder.Property(R => R.IsDeleted).IsRequired();


        }
    }
}
