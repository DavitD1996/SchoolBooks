using SchoolBooks.Entities;

namespace SchoolBooks.Repository.Interfaces
{
    public interface IBookRepository:IGeneralRepository<Book>
    {
        Task<Book>GetBookByCredentials(string publisher, string name, int classroom);
    }
}
