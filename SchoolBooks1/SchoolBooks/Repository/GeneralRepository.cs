using Microsoft.EntityFrameworkCore;
using SchoolBooks.Context;
using SchoolBooks.Repository.Interfaces;
using System.Linq.Expressions;

namespace SchoolBooks.Repository
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
    {
        internal SchoolBooksContext context;
        internal DbSet<TEntity> dbSet;

        public GeneralRepository(SchoolBooksContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
      
        public async Task AddEntityAsync(TEntity entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<ICollection<TEntity>> GetEntitiesAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return await orderBy(query).ToListAsync();
                }
                else
                {
                    return await query.ToListAsync();
                }
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveByIdAsync(object id)
        {
            try
            {
                TEntity removeCandidate = await dbSet.FindAsync(id);
                RemoveEntity(removeCandidate);
            }
            catch
            {
                throw;
            }
        }

        public void RemoveEntity(TEntity entity)
        {
            try
            {
                dbSet.Remove(entity);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateByIdAsync(object id)
        {
            try
            {
                TEntity updateEntity= await dbSet.FindAsync(id);
                UpdateEntity(updateEntity);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateEntity(TEntity entity)
        {
            try
            {
                dbSet.Update(entity);
            }
            catch
            {
                throw;
            }
        }
        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
