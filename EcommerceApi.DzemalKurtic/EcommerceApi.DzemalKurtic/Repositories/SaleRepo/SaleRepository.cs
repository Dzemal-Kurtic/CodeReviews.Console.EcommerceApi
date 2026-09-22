using EcommerceApi.DzemalKurtic.Data;
using EcommerceApi.DzemalKurtic.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.DzemalKurtic.Repositories.SaleRepo;

public class SaleRepository : ISaleRepository
{
    private readonly EcommerceDbContext _context;
    public SaleRepository(EcommerceDbContext context)
    {
        _context = context;
    }
    public async Task<Sale> AddAsync(Sale sale)
    {
        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();
        return sale;
    }

    public async Task<List<Sale>> GetAllAsync()
    {
        return await SalesWithItems()
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync();
    }

    public async Task<Sale?> GetByIdAsync(int id)
    {
        return await SalesWithItems()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<List<Sale>> GetByDateRangeAsync(DateTime from, DateTime to)
    {
        return await SalesWithItems()
            .Where(s => s.CreatedAt >= from && s.CreatedAt <= to)
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync();
    }

    private IQueryable<Sale> SalesWithItems()
    {
        return _context.Sales.IgnoreQueryFilters()
            .Include(s => s.Items)
            .ThenInclude(i => i.Product);
    }
}
