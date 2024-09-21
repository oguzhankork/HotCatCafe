using HotCatCafe.Model.Base;

namespace HotCatCafe.Model.Entities
{
    public class SubCategory:BaseEntity
    {
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
