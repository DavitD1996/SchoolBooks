using Microsoft.EntityFrameworkCore;
using SchoolBooks.Context;
using SchoolBooks.Entities;
using SchoolBooks.Repository.Interfaces;

namespace SchoolBooks.Repository
{
    public class SchoolRepository : GeneralRepository<School>,ISchoolRepository
    {
        public SchoolRepository(SchoolBooksContext context) : base(context)
        {
        }
    }
}
