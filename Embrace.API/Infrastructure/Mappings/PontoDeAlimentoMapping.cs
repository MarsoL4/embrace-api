using Embrace.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Embrace.API.Infrastructure.Mappings
{
    public class PontoDeAlimentoMapping : IEntityTypeConfiguration<PontoDeAlimento>
    {
        public void Configure(EntityTypeBuilder<PontoDeAlimento> builder)
        {
            builder.ToTable("PONTOS_DE_ALIMENTO");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.NomeLocal)
                .HasColumnName("NOME_LOCAL")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Endereco)
                .HasColumnName("ENDERECO")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Capacidade)
                .HasColumnName("CAPACIDADE")
                .IsRequired();
        }
    }
}