
using LibraryDb_Gabriel_Viinikka.Models;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace LibraryDb_Gabriel_Viinikka
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var printedEnv = environment ?? string.Empty;
            Console.WriteLine($"Environment set to {printedEnv.ToUpper()}");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

          
            var connectionString = builder.Configuration.GetConnectionString("BooksDb");

            if (environment == "Azure")
            {
                builder.Configuration.AddUserSecrets("9c0687a4-2bff-43da-9423-987d8bbbe253");
                connectionString = builder.Configuration.GetConnectionString("AzureDB");
                var connectionBuilder = new SqlConnectionStringBuilder(connectionString)
                {
                    Password = builder.Configuration["AzureDbPassword"]
                };
                connectionString = connectionBuilder.ConnectionString;
            }

            Console.WriteLine(connectionString);

            builder.Services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(connectionString).LogTo(message => Debug.WriteLine(message)).EnableSensitiveDataLogging().EnableDetailedErrors();
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
           
                app.UseSwagger();
                app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
