using EcommerceApi.DzemalKurtic.Interfaces;

namespace EcommerceApi.DzemalKurtic.Models;

public class Product : ISoftDeletable
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public List<SaleItem> SaleItems { get; set; } = new();
}
