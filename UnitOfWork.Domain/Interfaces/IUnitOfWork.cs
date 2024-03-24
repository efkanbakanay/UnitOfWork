using Microsoft.EntityFrameworkCore.Storage;
using UnitOfWork.Core.Interfaces;

namespace UnitOfWork.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        void CreateTransaction();
        void Commit();
        void Rollback();
        IRepository<T> Repository<T>() where T : class;
       

    }
}
