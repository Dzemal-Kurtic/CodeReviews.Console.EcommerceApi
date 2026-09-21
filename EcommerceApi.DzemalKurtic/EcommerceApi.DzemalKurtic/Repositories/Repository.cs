using EcommerceApi.DzemalKurtic.Data;
using EcommerceApi.DzemalKurtic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.DzemalKurtic.Repositories;

public class Repository<T> : IRepository<T> where T : class, ISoftDeletable, IEntity
{
    protected readonly EcommerceDbContext _context;
    protected readonly DbSet<T> _set;
    public Repository(EcommerceDbContext context)
    {
        _context = context;
        _set = context.Set<T>();
    }
    public async Task<T> AddAsync(T entity)
    {
        _set.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _set.ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _set.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
        {
            return false;
        }
        entity.IsDeleted = true;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task UpdateAsync(T entity)
    {
        _set.Update(entity);
        await _context.SaveChangesAsync();
    }
}

