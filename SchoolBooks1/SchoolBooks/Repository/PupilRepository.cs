using Microsoft.EntityFrameworkCore;
using SchoolBooks.Context;
using SchoolBooks.Entities;
using SchoolBooks.Repository.Interfaces;

namespace SchoolBooks.Repository
{
    public class PupilRepository : GeneralRepository<Pupil>, IPupilRepository
    {
        public PupilRepository(SchoolBooksContext context) : base(context)
        {
        }

        public async Task<ICollection<Book>> GetAllBooksForCertainPupil(string pupilId)
        {
            return await context.Pupils
               .Include(p => p.Books)
               .Where(p => p.Id == pupilId)
               .SelectMany(p => p.Books)
               .ToListAsync();
        }

        public async Task<Pupil> GetPupilWithSchoolandBooks(string pupilId)
        {
            return await context.Pupils
              .Include(p => p.Books)
              .Include(p => p.School)
              .FirstOrDefaultAsync(p => p.Id == pupilId);
        }
    }
}
