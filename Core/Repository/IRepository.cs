using backend.Core.Model;
using System.Linq.Expressions;

namespace backend.Core.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);

        Task<IEnumerable<T>> GetWithCondition(Expression<Func<T, bool>> exp);

        Task<T?> GetById(Guid id);

        Task<bool> ExistsAny(Expression<Func<T, bool>> exp);

        Task<T> Create(T entity);

        public T Update(T entity);
      
        public T Delete(T entity);

        Task SaveChanges(CancellationToken cancellationToken = default);
       
    }
}
