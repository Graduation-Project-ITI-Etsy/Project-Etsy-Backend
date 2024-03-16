using Esty_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Context.Configration
{
    public class OrderItemConfigration : IEntityTypeConfiguration<OrderItem>
    {


        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            //Constrains On Properities :

            builder.HasKey(b => b.OrderItemId);

            builder.Property(oi => oi.Quantity).IsRequired();


            //>>Product-OrderItems:
            //builder.HasOne(oi => oi.Product)
            //.WithMany(p => p.OrderItems)
            //.HasForeignKey(oi => oi.ProductId);

        }
    }
}
