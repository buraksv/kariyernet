using System;
using System.Threading.Tasks;

namespace KariyerNetBackendTestCase.Core.DataAccess.Abstract
{
    public interface IUnitOfWork<TContext>  : IDisposable
    { 
        TContext Context { get; }
        void TransactionStart();
        void TransactionDispose();
        void TransactionComplete();
        void TransactionRollback();
        T GetRepository<T>();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
