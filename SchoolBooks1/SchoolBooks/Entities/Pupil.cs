using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBooks.Entities
{
    public class Pupil
    {
        [Key]
        public string Id { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public int Class { get; set; }
        [ForeignKey("School")]
        public string SchoolName { get; set; }
        public School School { get; set; }
        public ICollection<Book>? Books { get; set; }
        public Pupil(string id)
        {
            Id= id;
        }
        public Pupil() { }
    }
}
