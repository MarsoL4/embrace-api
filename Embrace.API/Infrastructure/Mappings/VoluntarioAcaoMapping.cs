using Embrace.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Embrace.API.Infrastructure.Mappings
{
    public class VoluntarioAcaoMapping : IEntityTypeConfiguration<VoluntarioAcao>
    {
        public void Configure(EntityTypeBuilder<VoluntarioAcao> builder)
        {
            builder.ToTable("VOLUNTARIO_ACAO");

            builder.HasKey(va => new { va.VoluntarioId, va.AcaoSolidariaId });

            builder.Property(va => va.VoluntarioId)
                .HasColumnName("VOLUNTARIO_ID")
                .HasColumnType("NUMBER(19)");

            builder.Property(va => va.AcaoSolidariaId)
                .HasColumnName("ACAO_SOLIDARIA_ID")
                .HasColumnType("NUMBER(19)");

            builder.HasOne(va => va.Voluntario)
                .WithMany(v => v.Acoes)
                .HasForeignKey(va => va.VoluntarioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(va => va.AcaoSolidaria)
                .WithMany(a => a.Voluntarios)
                .HasForeignKey(va => va.AcaoSolidariaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}