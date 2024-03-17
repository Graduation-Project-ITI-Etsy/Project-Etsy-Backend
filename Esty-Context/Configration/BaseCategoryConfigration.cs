using Esty_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Context.Configration
{
    public class BaseCategoryConfigration : IEntityTypeConfiguration<BaseCategory>
    {
        public void Configure(EntityTypeBuilder<BaseCategory> builder)
        {

            builder.HasKey(bc => bc.Id);

            builder.HasMany(bc => bc.Categories)
                .WithOne(c => c.BaseCategory)
                .HasForeignKey(c => c.BaseCategoryId);
        }

    }
}
