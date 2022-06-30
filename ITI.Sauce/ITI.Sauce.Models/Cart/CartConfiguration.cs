using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Sauce.Models
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(C => C.ID);
            builder.Property(C => C.ID).ValueGeneratedOnAdd();
            builder.Property(C => C.UserID).HasMaxLength(450).IsRequired();
            builder.Property(C => C.Qty).HasMaxLength(50).IsRequired();
            builder.Property(C => C.Recipe_ID).HasMaxLength(50).IsRequired();

        }
    }
}
