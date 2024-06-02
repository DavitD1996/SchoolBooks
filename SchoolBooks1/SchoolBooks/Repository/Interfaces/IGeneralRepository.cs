using System.Linq.Expressions;

namespace SchoolBooks.Repository.Interfaces
{
    public interface IGeneralRepository<TEntity> where TEntity : class
    {
        Task AddEntityAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(object id);
        Task<ICollection<TEntity>> GetEntitiesAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task RemoveByIdAsync(object id);
        void RemoveEntity (TEntity entity);
        Task UpdateByIdAsync(object id);
        void UpdateEntity(TEntity entity);
        Task SaveChanges();
    }
}
