using EcommerceApi.DzemalKurtic.Interfaces;

namespace EcommerceApi.DzemalKurtic.Models;

public class Sale : IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<SaleItem> Items { get; set; } = new();
}
