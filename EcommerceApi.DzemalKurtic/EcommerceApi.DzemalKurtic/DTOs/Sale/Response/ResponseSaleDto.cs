namespace EcommerceApi.DzemalKurtic.DTOs.Sale.Response;

public record ResponseSaleDto(
    int Id,
    DateTime CreatedAt,
    decimal Total,
    List<ResponseSaleItemDto> Items
    );
