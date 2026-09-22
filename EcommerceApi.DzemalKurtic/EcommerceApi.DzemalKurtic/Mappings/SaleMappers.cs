using EcommerceApi.DzemalKurtic.DTOs.Sale.Response;
using EcommerceApi.DzemalKurtic.Models;

namespace EcommerceApi.DzemalKurtic.Mappings;

public static class SaleMappers
{
    public static ResponseSaleItemDto ToResponseDto(this SaleItem saleItem)
    {
        return new ResponseSaleItemDto(
            saleItem.ProductId, saleItem.Product.Name, saleItem.Quantity,
            saleItem.SalePrice, saleItem.Quantity * saleItem.SalePrice
            );
    }

    public static ResponseSaleDto ToResponseDto(this Sale sale)
    {
        var items = sale.Items.Select(i => i.ToResponseDto()).ToList();
        var total = items.Sum(i => i.LineTotal);
        return new ResponseSaleDto(
            sale.Id, sale.CreatedAt, total, items
            );
    }
}
