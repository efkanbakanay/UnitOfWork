using Microsoft.EntityFrameworkCore;
using UnitOfWork.Core.Interfaces;

namespace UnitOfWork.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppContext _dbContext;
    private DbSet<T> _dbSet;
    public Repository(AppContext context)
    {
        _dbContext = context;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
