using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Sauce.Models
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(O=>O.ID);
            builder.Property(O => O.ID).ValueGeneratedOnAdd();
            builder.Property(O=>O.NameEN).HasMaxLength(500).IsRequired();
            builder.Property(O => O.NameAR).HasMaxLength(500).IsRequired();
            builder.Property(O => O.registerDate).IsRequired();
            builder.Property(O => O.IsDeleted).IsRequired();
            builder.Property(O => O.Recipe_ID).ValueGeneratedOnAdd();


        }
    }
}
