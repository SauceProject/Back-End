using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Sauce.Models

{
    public class Vendor_MemberShipConfiguration : IEntityTypeConfiguration<Vendor_MemberShip>
    {
        public void Configure(EntityTypeBuilder<Vendor_MemberShip> builder)
        {
            builder.ToTable("Vendor_MemberShip");
            builder.HasKey(vm => new { vm.Vendor_ID, vm.MemberShip_ID });
            builder.Property(vm => vm.Vendor_ID).IsRequired();
            builder.Property(vm => vm.MemberShip_ID).IsRequired();
            builder.Property(vm => vm.NumberOfOrders);
            builder.Property(vm => vm.IsValid).HasDefaultValue(false);
        }
    }
}
