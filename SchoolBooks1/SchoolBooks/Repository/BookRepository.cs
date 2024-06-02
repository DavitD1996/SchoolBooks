using Microsoft.EntityFrameworkCore;
using SchoolBooks.Context;
using SchoolBooks.Entities;
using SchoolBooks.Repository.Interfaces;

namespace SchoolBooks.Repository
{
    public class BookRepository:GeneralRepository<Book>,IBookRepository
    {
        public BookRepository(SchoolBooksContext context) : base(context) { }

        public async Task<Book> GetBookByCredentials(string publisher, string name, int classroom)
        {
            return  await context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Pupils)
                .FirstOrDefaultAsync(b => b.PublisherName == publisher && b.Name == name && b.Class == classroom);
        }
    }
}
