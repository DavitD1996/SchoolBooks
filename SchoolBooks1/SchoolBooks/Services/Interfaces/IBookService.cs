using SchoolBooks.Services.DTO;

namespace SchoolBooks.Services.Interfaces
{
    public interface IBookService<TDtoRead, TDtoWrite> : IGeneralService<TDtoRead, TDtoWrite>
        where TDtoRead : class
        where TDtoWrite : class
    {
    }
}
