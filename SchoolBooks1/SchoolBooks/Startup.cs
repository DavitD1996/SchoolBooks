namespace SchoolBooks
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SchoolBooks.Context;
    using SchoolBooks.Entities;
    using SchoolBooks.Repository;
    using SchoolBooks.Repository.Interfaces;
    using SchoolBooks.Services;
    using SchoolBooks.Services.DTO.Pupils;
    using SchoolBooks.Services.DTO.School;
    using SchoolBooks.Services.DTO.SchoolBook;
    using SchoolBooks.Services.Helpers;
    using SchoolBooks.Services.Interfaces;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SchoolBooksContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IPupilRepository, PupilRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IBookService<SchoolBookDTORead,SchoolBookDtoWrite>, SchoolBookService>();
            services.AddScoped<ISchoolService<SchoolDto,SchoolDto>,SchoolService>();
            services.AddScoped<IPupilService<PupilsDtoRead,PupilDtoRegistration>, PupilService>();  
            //services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, ApplicationDbContext context*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    SeedData.Initialize(services);
                }
                catch (Exception)
                {
                    // Handle the error (you could write to a file, console, etc., if needed)
                    throw;
                }
            }

        }
    }

}
