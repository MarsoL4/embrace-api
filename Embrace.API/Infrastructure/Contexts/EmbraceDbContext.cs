using Embrace.API.Infrastructure.Mappings;
using Embrace.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Embrace.API.Infrastructure.Contexts
{
    public class EmbraceDbContext : DbContext
    {
        public EmbraceDbContext(DbContextOptions<EmbraceDbContext> options) : base(options) { }

        public DbSet<Ong> Ongs { get; set; }
        public DbSet<AcaoSolidaria> AcoesSolidarias { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<VoluntarioAcao> VoluntarioAcoes { get; set; }
        public DbSet<PontoDeAlimento> PontosDeAlimento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OngMapping());
            modelBuilder.ApplyConfiguration(new AcaoSolidariaMapping());
            modelBuilder.ApplyConfiguration(new DoacaoMapping());
            modelBuilder.ApplyConfiguration(new VoluntarioMapping());
            modelBuilder.ApplyConfiguration(new VoluntarioAcaoMapping());
            modelBuilder.ApplyConfiguration(new PontoDeAlimentoMapping());
        }
    }
}
