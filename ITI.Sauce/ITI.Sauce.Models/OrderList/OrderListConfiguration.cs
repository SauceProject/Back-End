using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Sauce.Models
{
    public class OrderListConfiguration : IEntityTypeConfiguration<OrderList>
    {
        public void Configure(EntityTypeBuilder<OrderList> builder)
        {
            builder.ToTable("OrderList");
            builder.HasKey(OL=>OL.OrderListID);
            builder.Property(OL => OL.OrderListID).ValueGeneratedOnAdd();
            builder.Property(OL => OL.OrderListQty).IsRequired();
            builder.Property(OL => OL.Recipe_ID).IsRequired();
            builder.Property(OL => OL.OrderListPrice).IsRequired();
            builder.Property(OL => OL.OrderID).IsRequired();


        }
    }
}
