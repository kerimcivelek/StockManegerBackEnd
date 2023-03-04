using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           
            builder.Property(I => I.Capacity).IsRequired();
            builder.Property(I => I.Colour).IsRequired();
            builder.Property(I => I.CategoryId).IsRequired();
            builder.Property(I => I.BrandId).IsRequired();
        }
    }
}
