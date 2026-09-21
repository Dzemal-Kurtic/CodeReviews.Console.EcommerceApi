using EcommerceApi.DzemalKurtic.Interfaces;

namespace EcommerceApi.DzemalKurtic.Repositories;

public interface IRepository<T> where T : class, ISoftDeletable, IEntity
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task<bool> SoftDeleteAsync(int id);
}
