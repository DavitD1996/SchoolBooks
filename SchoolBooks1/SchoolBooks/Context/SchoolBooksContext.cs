using Microsoft.EntityFrameworkCore;
using SchoolBooks.Entities;

namespace SchoolBooks.Context
{
    public class SchoolBooksContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book>Books { get; set; }
        public SchoolBooksContext(DbContextOptions<SchoolBooksContext> options) : base(options)
        {

        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pupil>()
                .HasMany(p => p.Books)
                .WithMany(b => b.Pupils)
                .UsingEntity(j => j.ToTable("PupilBooks")); // Optional: Customize join table name
        }*/
    }
}
