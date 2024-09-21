using HotCatCafe.API.DTOs.CategoryDtos;
using HotCatCafe.API.DTOs.ProductDtos;
using HotCatCafe.Model.Enums;

namespace HotCatCafe.API.DTOs.SubCategoryDtos
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool IsActive { get; set; }
        public DataStatus Status { get; set; }
        public List<ProductDto>? ProductDtos { get; set; }
        public List<CategoryDto>? CategoryDtos { get; set; }
    }
}
