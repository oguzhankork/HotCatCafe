using HotCatCafe.Model.Entities;
using HotCatCafe.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotCatCafe.DAL.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(x => x.PaymentType).HasConversion(y => y.ToString(), y => (PaymentType)Enum.Parse(typeof(PaymentType), y));  //Veritabanında yazı olarak ödeme tipi gözükmesi için oluşturuldu.
            builder.Property(x => x.TotalPayment).HasPrecision(18, 2); //Toplam ödeme alanı 18 basamaklı ve 2 ondalık basamağa sahip olacak şekilde tanımlandı. Parasal değerlerin doğruluğunu korumak için.

            builder.HasOne(x => x.Order).WithOne(x => x.Payment).HasForeignKey<Payment>(x => x.OrderId);
        }
    }
}
