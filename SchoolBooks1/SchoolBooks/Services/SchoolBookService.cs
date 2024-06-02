using SchoolBooks.Services.DTO.SchoolBook;
using SchoolBooks.Services.Interfaces;

namespace SchoolBooks.Services
{
    public class SchoolBookService : IBookService<SchoolBookDTORead, SchoolBookDtoWrite>
    {
        public Task AddAsync(SchoolBookDtoWrite dto)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<SchoolBookDTORead>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SchoolBookDTORead> GetByIDAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(object id)
        {
            throw new NotImplementedException();
        }
    }
}
