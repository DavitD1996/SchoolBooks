using SchoolBooks.Entities;

namespace SchoolBooks.Repository.Interfaces
{
    public interface IPupilRepository:IGeneralRepository<Pupil>
    {
        Task<ICollection<Book>> GetAllBooksForCertainPupil(string pupilId);
        Task<Pupil> GetPupilWithSchoolandBooks(string pupilId);
    }
}
