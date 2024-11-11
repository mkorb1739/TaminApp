using Microsoft.EntityFrameworkCore.Storage;
using TaminApp.Models;

namespace TaminApp.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;

        Task BeginTransactionAsync();
        Task<int> CommitAsync();
        Task RollbackAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaminDB _context;
        private IDbContextTransaction _transaction;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(TaminDB context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repository = new Repository<T>(_context);
                _repositories.Add(typeof(T), repository);
            }

            return (IRepository<T>)_repositories[typeof(T)];
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
        }

        public async Task<int> CommitAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction has not been started. Call BeginTransactionAsync first.");

            try
            {
                int result = await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
                return result;
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await DisposeTransactionAsync();
            }
        }

        private async Task DisposeTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            DisposeTransactionAsync().GetAwaiter().GetResult();
            _context.Dispose();
        }
    }
}
