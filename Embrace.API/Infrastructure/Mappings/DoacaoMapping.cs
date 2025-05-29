using Embrace.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Embrace.API.Infrastructure.Mappings
{
    public class DoacaoMapping : IEntityTypeConfiguration<Doacao>
    {
        public void Configure(EntityTypeBuilder<Doacao> builder)
        {
            builder.ToTable("DOACOES");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasColumnName("ID")
                .HasColumnType("NUMBER(19)")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.Tipo)
                .HasColumnName("TIPO")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.Quantidade)
                .HasColumnName("QUANTIDADE")
                .IsRequired();

            builder.Property(d => d.DataRecebida)
                .HasColumnName("DATA_RECEBIDA")
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(d => d.AcaoSolidariaId)
                .HasColumnName("ACAO_SOLIDARIA_ID")
                .IsRequired();

            builder.HasOne(d => d.AcaoSolidaria)
                .WithMany(a => a.Doacoes)
                .HasForeignKey(d => d.AcaoSolidariaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}