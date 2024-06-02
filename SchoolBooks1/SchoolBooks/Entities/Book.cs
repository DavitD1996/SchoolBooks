using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBooks.Entities
{
    public class Book
    {
        [Key]
        public string Id { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Class { get; set; }
        [ForeignKey("Publisher")]
        public string PublisherName { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<Pupil> Pupils { get; set; }
        public Book(string BookId)
        {
            Id = BookId;
        }
        public Book() { }
    }
}
