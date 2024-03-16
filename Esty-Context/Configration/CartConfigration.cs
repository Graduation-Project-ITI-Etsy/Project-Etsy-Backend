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
    public class CartConfigration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(C => C.CartID);

            builder.Property(C => C.Quantity).HasColumnType("int").IsRequired();

            builder.HasOne(C => C.customer)
            .WithMany(C => C.Carts)
            .HasForeignKey(C => C.CustomerId);

            builder.HasOne(P => P.products)
            .WithMany(P => P.carts)
            .HasForeignKey(P => P.ProductId);
        }
    }
}
