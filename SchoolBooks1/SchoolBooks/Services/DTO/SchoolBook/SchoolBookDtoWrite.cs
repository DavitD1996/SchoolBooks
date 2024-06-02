using SchoolBooks.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolBooks.Services.DTO.SchoolBook
{
    public class SchoolBookDtoWrite
    {
        public string Id { get; set; }
        public string Name { get; set; }
       
        public int Class { get; set; }
       
        public string PublisherName { get; set; }
        public static Book BookFromDto(SchoolBookDtoWrite dto)
        {
            return new Book(dto.Id)
            {
                Name = dto.Name,
                Class = dto.Class,
                PublisherName = dto.PublisherName,
            };
        }
    }
}
