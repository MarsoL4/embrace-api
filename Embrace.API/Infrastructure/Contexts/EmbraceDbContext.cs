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
            modelBuilder.Entity<VoluntarioAcao>()
                .HasKey(va => new { va.VoluntarioId, va.AcaoSolidariaId });
        }
    }
}
