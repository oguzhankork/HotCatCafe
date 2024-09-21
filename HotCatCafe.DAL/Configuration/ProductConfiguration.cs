using HotCatCafe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotCatCafe.DAL.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x => x.SubCategory).WithMany(x => x.Products).HasForeignKey(x => x.SubCategoryId);
            builder.Property(x => x.ProductName).IsRequired(true);
            builder.Property(x => x.ProductName).HasMaxLength(150);
            builder.Property(x => x.ImagePath).IsRequired(false);
            builder.Property(x=>x.MinStockLevel).IsRequired(false);
            builder.Property(x => x.UnitPrice).HasPrecision(18, 2);
        }     
    }
}
