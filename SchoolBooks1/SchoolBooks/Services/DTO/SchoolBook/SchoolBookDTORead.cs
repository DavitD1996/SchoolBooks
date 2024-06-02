using SchoolBooks.Entities;

namespace SchoolBooks.Services.DTO.SchoolBook
{
    public class SchoolBookDTORead
    {
        public string Title { get; set; }
        public int Class { get; set; }
        public static SchoolBookDTORead getSchoolBookDtoFromEntity(Book book)
        {
            return new SchoolBookDTORead()
            {
                Title = book.Name,
                Class = book.Class
            };
        }
    }
}
