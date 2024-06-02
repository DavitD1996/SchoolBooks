using SchoolBooks.Services.DTO.Pupils;
using SchoolBooks.Services.DTO.SchoolBook;

namespace SchoolBooks.Services.Interfaces
{
    public interface IPupilService<TDtoRead, TDtoWrite> : IGeneralService<TDtoRead, TDtoWrite>
        where TDtoRead : class
        where TDtoWrite : class
    {
        Task<ICollection<SchoolBookDTORead>> GetAllBooksOfPupil(string pupilId);
        Task AddBookToPupil(string pupilId, SchoolBookDtoWrite bookDto);
    }
}
