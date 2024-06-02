using SchoolBooks.Entities;
using SchoolBooks.Repository.Interfaces;
using SchoolBooks.Services.DTO.Pupils;
using SchoolBooks.Services.DTO.SchoolBook;
using SchoolBooks.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace SchoolBooks.Services
{
    public class PupilService : IPupilService<PupilsDtoRead, PupilDtoRegistration>
    {
        private readonly IPupilRepository _pupilRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IBookRepository _bookRepository;
        public PupilService(IPupilRepository pupilRepository,ISchoolRepository schoolRepository,IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _schoolRepository = schoolRepository;
            _pupilRepository= pupilRepository;
        }
        public async Task AddAsync(PupilDtoRegistration dto)
        {
            try
            {
                Pupil newPupil = PupilDtoRegistration.GetPupilEntityFromDto(dto);
                newPupil.School = await _schoolRepository.GetByIdAsync(newPupil.Id);
                newPupil.Books = null;
                _pupilRepository.AddEntityAsync(newPupil);
                await _pupilRepository.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ICollection<PupilsDtoRead>> GetAllAsync()
        {
            try
            {
                ICollection<PupilsDtoRead> pupils = new List<PupilsDtoRead>() { };
                var entities = await _pupilRepository.GetEntitiesAsync();
                foreach (var entity in entities)
                {
                    pupils.Add(PupilsDtoRead.GetPupilDtoFromEntity(entity));
                }
                return pupils;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ICollection<PupilsDtoRead>> GetWithFiltersAsync(Expression<Func<Pupil, bool>> filter)
        {
            try
            {
                ICollection<PupilsDtoRead> result = new List<PupilsDtoRead>() { };
                ICollection<Pupil> pupils = await _pupilRepository.GetEntitiesAsync(filter: filter);
                foreach (var item in pupils)
                {
                    result.Add(PupilsDtoRead.GetPupilDtoFromEntity(item));
                }
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PupilsDtoRead> GetByIDAsync(object id)
        {
            try
            {
                Pupil pupil = await _pupilRepository.GetByIdAsync(id);
                return PupilsDtoRead.GetPupilDtoFromEntity(pupil);
            }
            catch
            {
                throw;
            }
        }

        public async Task RemoveAsync(object id)
        {
            try
            {
                await _pupilRepository.RemoveByIdAsync(id);
                await _pupilRepository.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Task UpdateAsync(object id)
        {
            throw new NotImplementedException();
        }
        public async Task<ICollection<SchoolBookDTORead>> GetAllBooksOfPupil(string pupilId)
        {
            try
            {
                ICollection<Book>books=await _pupilRepository.GetAllBooksForCertainPupil(pupilId);
                List<SchoolBookDTORead>booksDto=new List<SchoolBookDTORead>();
                foreach(var item in books)
                {
                    booksDto.Add(SchoolBookDTORead.getSchoolBookDtoFromEntity(item));
                }
                return booksDto;
            }
            catch
            {
                throw;
            }
        }
        public async Task AddBookToPupil(string pupilId, SchoolBookDtoWrite bookDto)
        {
            try
            {
                Book book = await _bookRepository.GetBookByCredentials(bookDto.PublisherName, bookDto.Name, bookDto.Class);
                if(book != null)
                {
                    Pupil pupil = await _pupilRepository.GetPupilWithSchoolandBooks(pupilId);
                    if (pupil.Books == null)
                    {
                        pupil.Books = new List<Book>();
                    }
                    pupil.Books.Add(book);
                    _pupilRepository.UpdateEntity(pupil);
                    _pupilRepository.SaveChanges();
                }
                else
                {
                    throw new ArgumentException();
                } 
            }
            catch
            {
                throw;
            }
        }

    }
}
