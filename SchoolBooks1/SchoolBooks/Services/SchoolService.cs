using AutoMapper;
using SchoolBooks.Entities;
using SchoolBooks.Repository;
using SchoolBooks.Repository.Interfaces;
using SchoolBooks.Services.DTO.Pupils;
using SchoolBooks.Services.DTO.School;
using SchoolBooks.Services.DTO.SchoolBook;
using SchoolBooks.Services.Interfaces;
using System.Linq.Expressions;

namespace SchoolBooks.Services
{
    public class SchoolService:ISchoolService<SchoolDto,SchoolDto>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IPupilRepository _pupilRepository;
        //private readonly Mapper _mapper;
        public SchoolService(ISchoolRepository schoolRepository/*Mapper mapper*/,IPupilRepository pupilRepository)
        {
            _schoolRepository = schoolRepository;
            _pupilRepository = pupilRepository;
        }

        public Task AddAsync(SchoolDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<SchoolDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PupilsDtoRead>> getAllPupilsOfCertainSchool(string schoolName)
        {
            try
            {
                ICollection<PupilsDtoRead> pupilsDto = new List<PupilsDtoRead>() { };
                ICollection<Pupil> pupils = await _pupilRepository.GetEntitiesAsync(s => s.SchoolName == schoolName);
                foreach (var item in pupils)
                {
                    pupilsDto.Add(PupilsDtoRead.GetPupilDtoFromEntity(item));
                }
                return pupilsDto;
            }
            catch
            {
                throw;
            }
        }

        public Task<SchoolDto> GetByIDAsync(object id)
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
