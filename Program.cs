
using Microsoft.EntityFrameworkCore;
using studentdb.Data;

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<StudentContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("StudentDb"));
            });
            
            var app = builder.Build();

           

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

        
