using Microsoft.EntityFrameworkCore;
using SchoolBooks.Context;
using SchoolBooks.Entities;

namespace SchoolBooks.Services.Helpers
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolBooksContext(
                serviceProvider.GetRequiredService<DbContextOptions<SchoolBooksContext>>()))
            {
                // Look for any existing data
                if (context.Books.Any() || context.Schools.Any() || context.Pupils.Any() || context.Publishers.Any())
                {
                    return; // Data has already been seeded
                }

                // Add your test data here
                Pupil p = new Pupil("AA1") { Name = "Vardan", SurName = "Mkrtchyan", Class = 7, };
                Pupil p1 = new Pupil("AA2") { Name = "Vardan2", SurName = "Mkrtchyan2", Class = 8, };
                Pupil p2 = new Pupil("AA3") { Name = "Vardan3", SurName = "Mkrtchyan3", Class = 8, };

                Publisher publisher = new Publisher("Antares") { Address = "aaaa" };
                School sch1 = new School("154") { };
                School sch2 = new School("102") { };

                Book b1 = new Book("1") { Class = 7, Name = "Book1", PublisherName = "Antares", Publisher = publisher };
                Book b2 = new Book("2") { Class = 8, Name = "Book2", PublisherName = "Antares", Publisher = publisher };
                Book b3 = new Book("3") { Class = 8, Name = "Book3", PublisherName = "Antares", Publisher = publisher };


                p.Books = new List<Book>() { b1 };
                p1.Books=new List<Book>() { b2,b3 };
                p2.Books=new List<Book>() { b3 ,b2};

                b1.Pupils=new List<Pupil>() { p };
                b2.Pupils=new List<Pupil>() { p1,p2 };
                b3.Pupils=new List<Pupil> { p1,p2 };

               publisher.Books=new List<Book> { b1,b2,b3 };

                sch1.Pupils = new List<Pupil>() { p };
                sch2.Pupils = new List<Pupil>() { p1, p2 };

                context.Pupils.AddRange(p, p1, p2);
                context.Books.AddRange(b1, b2, b3);
                context.Publishers.Add(publisher);
                context.Schools.AddRange(sch1, sch2);   
                
                context.SaveChanges();
            }
        }
    }
}
