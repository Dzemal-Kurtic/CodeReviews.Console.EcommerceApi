using EcommerceApi.DzemalKurtic.Models;

namespace EcommerceApi.DzemalKurtic.Repositories.CategoryRepo;

public interface ICategoryRepository : IRepository<Category>
{
    Task<bool> HasProductsAsync(int categoryId);
}
