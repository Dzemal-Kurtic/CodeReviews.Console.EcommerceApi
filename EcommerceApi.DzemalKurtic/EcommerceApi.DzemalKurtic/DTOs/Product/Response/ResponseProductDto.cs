namespace EcommerceApi.DzemalKurtic.DTOs.Product.Response;

public record ResponseProductDto(
    int Id,
    string Name,
    decimal Price,
    int CategoryId,
    string CategoryName
    );
