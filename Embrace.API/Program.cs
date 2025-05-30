using Embrace.API.Infrastructure.Contexts;
using Embrace.API.AutoMapper;
using Embrace.API.Services;
using Microsoft.EntityFrameworkCore;
using Embrace.API.Infrastructure.Repositories;

namespace Embrace.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurações de serviços
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("Oracle");

            builder.Services.AddDbContext<EmbraceDbContext>(options =>
                options.UseOracle(connectionString));

            // Registro do AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Registro do Repository e Service (exemplo: Ong)
            builder.Services.AddScoped<IOngRepository, OngRepository>();
            builder.Services.AddScoped<OngService>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}