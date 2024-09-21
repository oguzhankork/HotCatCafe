using HotCatCafe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotCatCafe.DAL.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.SubCategories).WithOne(y => y.Category).HasForeignKey(z => z.CategoryId);

            builder.Property(x => x.Description).HasMaxLength(150);
            builder.Property(x => x.CategoryName).HasMaxLength(50);
            builder.HasData(SeedCategory());
        }

        private List<Category> SeedCategory()
        {
            List<Category> categories = new List<Category>();

            categories.Add(new Category
            {
                ID = 1,
                CategoryName = "Yemek",
                Description = "Yiyecek ve Alt Kategorileri"
            });
            categories.Add(new Category
            {
                ID = 2,
                CategoryName = "Tatlı",
                Description = "Tatlı ve Alt Kategorileri"
            });
            categories.Add(new Category
            {
                ID = 3,
                CategoryName = "İçecek",
                Description = "İçecek ve Alt Kategorileri"
            });

            return categories;
        }
    }
}
