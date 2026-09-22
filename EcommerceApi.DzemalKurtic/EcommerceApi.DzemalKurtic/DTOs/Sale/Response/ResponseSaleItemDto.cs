namespace EcommerceApi.DzemalKurtic.DTOs.Sale.Response;

public record ResponseSaleItemDto(
    int ProductId,
    string ProductName,
    int Quantity,
    decimal SalePrice,
    decimal LineTotal
    );
