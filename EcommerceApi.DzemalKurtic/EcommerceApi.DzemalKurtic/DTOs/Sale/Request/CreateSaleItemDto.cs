using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.DzemalKurtic.DTOs.Sale.Request;

public record CreateSaleItemDto(
    [Range(1, int.MaxValue)] int ProductId,
    [Range(1, 10000)] int Quantity
    );
