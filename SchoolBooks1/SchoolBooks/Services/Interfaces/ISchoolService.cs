using SchoolBooks.Services.DTO;
using SchoolBooks.Services.DTO.Pupils;

namespace SchoolBooks.Services.Interfaces
{
    public interface ISchoolService<TDtoRead, TDtoWrite> : IGeneralService<TDtoRead, TDtoWrite>
        where TDtoRead : class
        where TDtoWrite : class
    {
        public Task<ICollection<PupilsDtoRead>> getAllPupilsOfCertainSchool(string shoolName);
    }
}
