using EcommerceApi.DzemalKurtic.Data;
using EcommerceApi.DzemalKurtic.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.DzemalKurtic.Repositories.ProductRepo;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(EcommerceDbContext context) : base(context)
    {

    }

    public override async Task<List<Product>> GetAllAsync()
    {
        return await _set.Include(p => p.Category).ToListAsync();
    }

    public override async Task<Product?> GetByIdAsync(int id)
    {
        return await _set.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Product>> GetByCategoryAsync(int categoryId)
    {
        return await _set.Where(p => p.CategoryId == categoryId).Include(p =>p.Category).ToListAsync();
    }
}
