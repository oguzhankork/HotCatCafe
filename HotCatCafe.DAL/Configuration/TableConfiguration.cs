using HotCatCafe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotCatCafe.DAL.Configuration
{
    internal class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.Property(x => x.TableNumber).HasMaxLength(50);
            builder.Property(x => x.TableSituation).IsRequired(false);
            
            builder
                .HasMany(x => x.TableSessions)
                .WithOne(x => x.Table)
                .HasForeignKey(x => x.TableId).OnDelete(DeleteBehavior.NoAction);//OnDelete metotu herhangi bir masa nesnesi silindiği zaman ilgili order tablosundaki sparişin silinmeyeceğini belirtir.

            builder.HasMany(x => x.Orders).WithOne(x => x.Table).HasForeignKey(x => x.TableId).OnDelete(DeleteBehavior.NoAction);
            builder.HasData(SeedTable());
        }
        private List<Table> SeedTable()
        {
            List<Table> tables = new List<Table>();
            tables.Add(new Table
            {
                ID = 1,
                TableName = "Bahçe 1",
                TableNumber = "B-1"
            });
            tables.Add(new Table
            {
                ID = 2,
                TableName = "Bahçe 2",
                TableNumber = "B-2"
            });
            tables.Add(new Table
            {
                ID = 3,
                TableName = "Salon 1",
                TableNumber = "S-1"
            });
            tables.Add(new Table
            {
                ID = 4,
                TableName = "Salon 2",
                TableNumber = "S-1"
            });
            return tables;
        }
    }
}
