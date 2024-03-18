using Esty_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esty_Context.Configration
{
    public class OrdersConfigration : IEntityTypeConfiguration<Orders>
    {


        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            //Constrains On Properities :
            builder.HasKey(b => b.OrdersId);

            builder.Property(c => c.Status).IsRequired().HasMaxLength(50);
            builder.Property(o => o.Address).IsRequired().HasMaxLength(255);
            builder.Property(o => o.TotalPrice).IsRequired();
            builder.Property(o => o.OrderedAt).IsRequired();
            builder.Property(o => o.ArrivedOn).IsRequired(false);


            //>>Customer-Orders:
            builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

            //>>OrderItems-Orders:
            builder.HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Orders)
            .HasForeignKey(oi => oi.OrdersId);

            //>>Payment-Orders:
            builder.HasOne(o => o.Payments)
            .WithOne(p => p.Orders)
            .HasForeignKey<Payments>(p => p.OrderId);



        }
    }

}

