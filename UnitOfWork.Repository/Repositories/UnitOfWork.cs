
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using UnitOfWork.Core.Interfaces;
using UnitOfWork.Domain.Interfaces;

namespace UnitOfWork.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppContext _dbContext;
    private IDbContextTransaction? _transaction;
    public IProductRepository Products { get; }

    public UnitOfWork(AppContext dbContext, IProductRepository productRepository)
    {
        _dbContext = dbContext;
        Products = productRepository;
        _transaction = dbContext.Database.BeginTransaction();
    }

    public Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Rollback()
    {
        _transaction?.Rollback();
        _transaction?.Dispose();
    }

    public IRepository<T> Repository<T>() where T : class
    {
        return new Repository<T>(_dbContext);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public int Save()
    {
        var result = _dbContext.SaveChanges();
        if (Convert.ToBoolean(result))
            _transaction?.Commit();
        else
            _transaction?.Rollback();

        _transaction?.Dispose();
        return result;

    }

    public void CreateTransaction()
    {
        _transaction = _dbContext.Database.BeginTransaction();
    }

    public void Commit()
    {
        _transaction?.Commit();
    }
}
