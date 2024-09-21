using HotCatCafe.API.DTOs.SubCategoryDtos;
using HotCatCafe.Model.Enums;

namespace HotCatCafe.API.DTOs.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DataStatus Status { get; set; }
        public List<SubCategoryDto>? SubCategories { get; set; }
    }
}
