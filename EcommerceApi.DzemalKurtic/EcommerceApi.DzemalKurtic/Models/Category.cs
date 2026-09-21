using EcommerceApi.DzemalKurtic.Interfaces;

namespace EcommerceApi.DzemalKurtic.Models;

public class Category : ISoftDeletable, IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }

    public List<Product> Products { get; set; } = new();
}
