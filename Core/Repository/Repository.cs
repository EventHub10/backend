using backend.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend.Core.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbContext _context { get; private set; }

        public Repository(DbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TEntity>> GetAll() 
        {
            var result = await _context.Set<TEntity>().ToListAsync();
            return result.AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> GetWithCondition(Expression<Func<TEntity, bool>> exp) 
        {
            var result = await _context.Set<TEntity>().Where(exp).ToListAsync();
            return result.AsEnumerable();   
        }

        public async Task<TEntity?> GetById(Guid id) 
        {
            var result = await _context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> ExistsAny(Expression<Func<TEntity, bool>> exp) 
        {
            var result = await _context.Set<TEntity>().AnyAsync(exp);
            return result;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (_context.Entry(entity).State != EntityState.Added)
            {
                _context.Set<TEntity>().Update(entity);
            }
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return entity;
        }

        public async Task SaveChanges(CancellationToken cancellationToken = default) 
        {
            await _context.SaveChangesAsync(cancellationToken);
        }


    }
}
