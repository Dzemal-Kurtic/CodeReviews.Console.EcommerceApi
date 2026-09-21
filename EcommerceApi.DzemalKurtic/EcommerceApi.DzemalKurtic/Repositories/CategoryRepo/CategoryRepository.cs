using EcommerceApi.DzemalKurtic.Data;
using EcommerceApi.DzemalKurtic.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.DzemalKurtic.Repositories.CategoryRepo;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(EcommerceDbContext context) : base(context)
    {
    }

    public async Task<bool> HasProductsAsync(int categoryId)
    {
        return await _context.Products.AnyAsync(p => p.CategoryId == categoryId);
    }
}
