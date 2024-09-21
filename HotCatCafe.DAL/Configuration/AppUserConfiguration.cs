using HotCatCafe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotCatCafe.DAL.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Address).IsRequired(false);
            builder.Property(x=>x.BirtDate).IsRequired(false);
            builder.Property(x => x.PhoneNumber).IsRequired(false);
        }
    }
}
