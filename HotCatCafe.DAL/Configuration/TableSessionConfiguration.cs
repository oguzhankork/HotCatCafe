using HotCatCafe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotCatCafe.DAL.Configuration
{
    public class TableSessionConfiguration : IEntityTypeConfiguration<TableSession>
    {
        public void Configure(EntityTypeBuilder<TableSession> builder)
        {
            builder.HasOne(x => x.Table).WithMany(x => x.TableSessions).HasForeignKey(x => x.TableId);

            builder.HasMany(x => x.OrderDetails).WithOne(x => x.TableSession).HasForeignKey(x => x.TableSessionId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
