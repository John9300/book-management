using BusinessLogic.Services;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BookManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = "Server=localhost\\SQLEXPRESS;Database=BookManagement;Trusted_Connection=True;TrustServerCertificate=True";
            builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddTransient<IBookService, BookService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}