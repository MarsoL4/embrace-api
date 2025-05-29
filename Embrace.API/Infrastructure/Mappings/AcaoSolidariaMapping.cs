using Embrace.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Embrace.API.Infrastructure.Mappings
{
    public class AcaoSolidariaMapping : IEntityTypeConfiguration<AcaoSolidaria>
    {
        public void Configure(EntityTypeBuilder<AcaoSolidaria> builder)
        {
            builder.ToTable("ACOES_SOLIDARIAS");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("ID")
                .HasColumnType("NUMBER(19)")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.TipoEvento)
                .HasColumnName("TIPO_EVENTO")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Cidade)
                .HasColumnName("CIDADE")
                .HasMaxLength(100);

            builder.Property(a => a.Estado)
                .HasColumnName("ESTADO")
                .HasMaxLength(50);

            builder.Property(a => a.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(300);

            builder.Property(a => a.MetaItens)
                .HasColumnName("META_ITENS");

            builder.Property(a => a.OngId)
                .HasColumnName("ONG_ID")
                .IsRequired();

            builder.HasOne(a => a.Ong)
                .WithMany(o => o.AcoesSolidarias)
                .HasForeignKey(a => a.OngId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}