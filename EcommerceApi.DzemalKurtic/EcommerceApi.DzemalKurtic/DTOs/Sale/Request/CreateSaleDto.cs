using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.DzemalKurtic.DTOs.Sale.Request;

public record CreateSaleDto(
    [Required, MinLength(1)] List<CreateSaleItemDto> Items
    );
