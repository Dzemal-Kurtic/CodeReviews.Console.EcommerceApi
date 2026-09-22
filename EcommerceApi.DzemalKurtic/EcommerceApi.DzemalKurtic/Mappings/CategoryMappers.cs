using EcommerceApi.DzemalKurtic.DTOs.Category.Response;
using EcommerceApi.DzemalKurtic.Models;

namespace EcommerceApi.DzemalKurtic.Mappings;

public static class CategoryMappers
{
    public static ResponseCategoryDto ToResponseDto(this Category category)
    {
        return new ResponseCategoryDto(category.Id, category.Name);
    }
}
