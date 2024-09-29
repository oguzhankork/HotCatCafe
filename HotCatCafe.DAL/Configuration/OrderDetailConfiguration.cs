using HotCatCafe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotCatCafe.DAL.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new
            {
                x.ProductId,    
                x.OrderId
            });                 // Burada Id yoksayılıp bir OrderDetail in hem bir ürüne hem de bir Order a bağlı olması için yapıldı.
            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
            builder.Property(x => x.UnitPrice).HasPrecision(18, 2);
        }
    }
}
