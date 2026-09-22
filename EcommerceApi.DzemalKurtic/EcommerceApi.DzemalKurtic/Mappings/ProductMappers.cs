using EcommerceApi.DzemalKurtic.DTOs.Product.Response;
using EcommerceApi.DzemalKurtic.Models;

namespace EcommerceApi.DzemalKurtic.Mappings;

public static class ProductMappers
{
    public static ResponseProductDto ToResponseDto(this Product product)
    {
        return new ResponseProductDto(product.Id, product.Name, product.Price, product.CategoryId, product.Category.Name);
    }
}
