using EcommerceApi.DzemalKurtic.Models;

namespace EcommerceApi.DzemalKurtic.Repositories.ProductRepo;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetByCategoryAsync(int categoryId);
}
