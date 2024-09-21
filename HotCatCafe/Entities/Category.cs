using HotCatCafe.Model.Base;

namespace HotCatCafe.Model.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
