using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Sauce.Models
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipe");
            builder.HasKey(r => r.ID);
            builder.Property(r => r.ID).ValueGeneratedOnAdd();
            builder.Property(r => r.ID).IsRequired();
            builder.Property(r=>r.ImageUrl).IsRequired();
            builder.Property(r => r.VideoUrl);
            builder.Property(r => r.Details).HasMaxLength(250);
            builder.Property(r => r.NameAR).HasMaxLength(30).IsRequired();
            builder.Property(r => r.NameEN).HasMaxLength(30).IsRequired();
            builder.Property(r => r.RegisterDate).HasDefaultValue(DateTime.Now);
        }
    }
}
