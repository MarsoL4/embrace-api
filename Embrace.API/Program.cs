using Embrace.API.Infrastructure.Contexts;
using Embrace.API.AutoMapper;
using Embrace.API.Services;
using Microsoft.EntityFrameworkCore;
using Embrace.API.Infrastructure.Repositories;
using Embrace.API.Infrastructure.Repositories.Interfaces;
using Embrace.API.Repositories.Interfaces;
using Embrace.API.Repositories;

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
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("Oracle");

            builder.Services.AddDbContext<EmbraceDbContext>(options =>
                options.UseOracle(connectionString));

            // Registro do AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Registro dos Repositories e Services
            builder.Services.AddScoped<IOngRepository, OngRepository>();
            builder.Services.AddScoped<OngService>();

            builder.Services.AddScoped<IVoluntarioRepository, VoluntarioRepository>();
            builder.Services.AddScoped<VoluntarioService>();

            builder.Services.AddScoped<IAcaoSolidariaRepository, AcaoSolidariaRepository>();
            builder.Services.AddScoped<AcaoSolidariaService>();

            builder.Services.AddScoped<IDoacaoRepository, DoacaoRepository>();
            builder.Services.AddScoped<DoacaoService>();

            builder.Services.AddScoped<IPontoDeAlimentoRepository, PontoDeAlimentoRepository>();
            builder.Services.AddScoped<PontoDeAlimentoService>();


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