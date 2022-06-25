using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ITI.Sauce.Models
{
    public class MemberShipConfiguration : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder)
        {
            builder.ToTable("MemberShip");
            builder.HasKey(ms => ms.ID);
            builder.Property(ms => ms.ID).ValueGeneratedOnAdd();
            builder.Property(ms => ms.Type).HasMaxLength(300).IsRequired();
            builder.Property(ms => ms.TypeEn).HasMaxLength(300).IsRequired();
            builder.Property(ms => ms.TypeAr).HasMaxLength(300).IsRequired();
            builder.Property(ms => ms.OrderNum).IsRequired();
            builder.Property(ms => ms.Price).IsRequired();
        }
    }
}
