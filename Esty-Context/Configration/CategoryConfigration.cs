using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esty_Models;


namespace Esty_Context.Configration
{
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
           

            builder.HasOne(c => c.BaseCategory)
                .WithMany(bc => bc.Categories)
                .HasForeignKey(c => c.BaseCategoryId);
        }
    }
}
