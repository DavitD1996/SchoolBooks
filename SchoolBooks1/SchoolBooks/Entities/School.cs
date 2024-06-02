using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SchoolBooks.Entities
{
    public class School
    {
        [Key]
        public string SchoolName { get; private set; }
        public ICollection<Pupil> Pupils { get; set; }
        public School(string name) 
        {
            SchoolName = name;
        }
        public School() { }
    }
}
