using EcommerceApi.DzemalKurtic.Models;

namespace EcommerceApi.DzemalKurtic.Repositories.SaleRepo;

public interface ISaleRepository
{
    Task<List<Sale>> GetAllAsync();
    Task<Sale?> GetByIdAsync(int id);
    Task<List<Sale>> GetByRangeDateAsync(DateTime from, DateTime to);
    Task<Sale> AddAsync(Sale sale);
}
