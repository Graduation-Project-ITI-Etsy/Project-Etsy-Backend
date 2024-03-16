using Esty_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Esty_Context.Configration
{
    public class ProductConfigration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(P => P.ProductId);

            builder.Property(P => P.ProductNameEN).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(P => P.ProductNameAR).HasColumnType("nvarchar(50)").IsRequired();

            builder.Property(P => P.ProductPublisher).HasColumnType("nvarchar(50)").IsRequired();

            builder.Property(P => P.ProductDescriptionEN).HasColumnType("nvarchar(MAX)").IsRequired();
            builder.Property(P => P.ProductDescriptionAR).HasColumnType("nvarchar(MAX)").IsRequired();
        }
    }
}
