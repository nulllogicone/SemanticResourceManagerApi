using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemanticResourceManager.DataAccess
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Guid Create(TEntity entity);
        Task<int> CreateAsync(TEntity entity);
        void Delete(Guid guid);
        Task DeleteAsync(Guid guid);
        TEntity Retrieve(Guid guid);
        TEntity Retrieve(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> RetrieveAll();
        Task<IEnumerable<TEntity>> RetrieveAllAsync();
        Task<TEntity> RetrieveAsync(Guid guid);
        Task<TEntity> RetrieveAsync(Func<TEntity, bool> predicate);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}