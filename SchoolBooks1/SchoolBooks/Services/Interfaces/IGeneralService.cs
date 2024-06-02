using System.Linq.Expressions;

namespace SchoolBooks.Services.Interfaces
{
    public interface IGeneralService<TDtoRead,TDtoWrite> 
        where TDtoRead :class
        where TDtoWrite : class
    {
        Task<ICollection<TDtoRead>> GetAllAsync();
        //Task<ICollection<TDtoRead>>GetWithFiltersAsync(Expression<Func<TEntity, bool>> filter);
        Task<TDtoRead> GetByIDAsync(object id);
        Task AddAsync(TDtoWrite dto);
        Task RemoveAsync(object id);
        Task UpdateAsync(object id);
    }
}
