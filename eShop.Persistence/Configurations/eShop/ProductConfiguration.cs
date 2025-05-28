using eShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Persistence.Configurations.eShop
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.ImageName).HasMaxLength(500);
            builder.Property(e => e.Category).HasMaxLength(100);
            builder.Property(e => e.Price).HasPrecision(18,2);
            builder.Property(e => e.Discount).HasPrecision(18, 2);
        }
    }
}
