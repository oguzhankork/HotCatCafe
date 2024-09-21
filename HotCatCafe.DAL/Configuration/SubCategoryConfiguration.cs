using HotCatCafe.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotCatCafe.DAL.Configuration
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasMany(x => x.Products).WithOne(y => y.SubCategory).HasForeignKey(z => z.SubCategoryId);
            builder.Property(x => x.SubCategoryName).HasMaxLength(60);
            builder.HasData(SeedSubCategory());
        }

        private ICollection<SubCategory> SeedSubCategory()
        {
            ICollection<SubCategory> subCategories = new HashSet<SubCategory>();


            subCategories.Add(new SubCategory()
            {
                ID = 4,
                SubCategoryName = "Çorbalar",
                CategoryId = 1
            });
            subCategories.Add(new SubCategory()
            {
                ID = 5,
                SubCategoryName = "Salatalar",
                CategoryId = 1
            });
            subCategories.Add(new SubCategory()
            {
                ID = 6,
                SubCategoryName = "Ana Yemekler",
                CategoryId = 1
            });
            subCategories.Add(new SubCategory()
            {
                ID = 7,
                SubCategoryName = "Sütlü Tatlılar",
                CategoryId = 2
            });
            subCategories.Add(new SubCategory()
            {
                ID = 8,
                SubCategoryName = "Şerbetli Tatlılar",
                CategoryId = 2
            });
            subCategories.Add(new SubCategory()
            {
                ID = 9,
                SubCategoryName = "Soğuk İçecekeler",
                CategoryId = 3
            });
            subCategories.Add(new SubCategory()
            {
                ID = 10,
                SubCategoryName = "Sıcak İçecekler",
                CategoryId = 3
            });
            return subCategories;
        }
    }
}
