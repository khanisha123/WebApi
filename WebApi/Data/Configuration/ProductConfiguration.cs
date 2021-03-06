using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Entity;

namespace WebApi.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.isDelete).HasDefaultValue(false);
            builder.Property(p => p.Price).IsRequired();
            //builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(p => p.CreatedAt).HasDefaultValue(DateTime.UtcNow);
        }
        
    }
}
