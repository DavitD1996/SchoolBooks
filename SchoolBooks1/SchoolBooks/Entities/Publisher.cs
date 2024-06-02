using System.ComponentModel.DataAnnotations;

namespace SchoolBooks.Entities
{
    public class Publisher
    {
        [Key]
        public string PublisherName { get; private set; }
        public string Address { get; set; }
        public ICollection<Book> Books { get; set; }
        public Publisher(string name)
        {
            PublisherName = name;
        }
        public Publisher() { }  
    }
}
