using SchoolBooks.Context;
using SchoolBooks.Entities;
using SchoolBooks.Repository.Interfaces;

namespace SchoolBooks.Repository
{
    public class PublisherRepository : GeneralRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(SchoolBooksContext context) : base(context)
        {
        }
    }
}
