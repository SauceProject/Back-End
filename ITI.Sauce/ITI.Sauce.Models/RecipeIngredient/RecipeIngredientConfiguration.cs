using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Sauce.Models
{
    public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.ToTable("RecipeIngredient").HasKey(ri => new { ri.RecipeID, ri.IngredientID });
            builder.Property(ri => ri.RecipeID).IsRequired();
            builder.Property(ri => ri.IngredientID).IsRequired();
            builder.Property(ri => ri.Qty).IsRequired();
            builder.Property(ri => ri.Type).HasMaxLength(50);

        }
    }
}
