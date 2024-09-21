using HotCatCafe.DAL.Configuration;
using HotCatCafe.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotCatCafe.DAL.Context
{
    public class HotCatCafeContext : IdentityDbContext<AppUser, AppUserRole, Guid>
    {
        public HotCatCafeContext(DbContextOptions<HotCatCafeContext> options) : base(options)
        {

        }

        //DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableSession> TableSessions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }


        //Config Çağırma
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());

            builder.ApplyConfiguration(new SubCategoryConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());

            builder.ApplyConfiguration(new TableConfiguration());

            builder.ApplyConfiguration(new TableSessionConfiguration());

            builder.ApplyConfiguration(new OrderConfiguration());

            builder.ApplyConfiguration(new OrderDetailConfiguration());
            
            builder.ApplyConfiguration(new PaymentConfiguration());

            base.OnModelCreating(builder);
        }

    }
}
