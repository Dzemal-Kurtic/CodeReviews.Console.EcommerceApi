using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.DzemalKurtic.DTOs.Product.Request;

public record UpdateProductDto(
    [Required] string Name,
    [Range(0.01, 1000000)] decimal Price,
    [Range(1, int.MaxValue)] int CategoryId
    );

