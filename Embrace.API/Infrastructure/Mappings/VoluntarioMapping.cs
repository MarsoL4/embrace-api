using Embrace.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Embrace.API.Infrastructure.Mappings
{
    public class VoluntarioMapping : IEntityTypeConfiguration<Voluntario>
    {
        public void Configure(EntityTypeBuilder<Voluntario> builder)
        {
            builder.ToTable("VOLUNTARIOS");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("ID")
                .HasColumnType("NUMBER(19)")
                .ValueGeneratedOnAdd();

            builder.Property(v => v.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(v => v.Telefone)
                .HasColumnName("TELEFONE")
                .HasMaxLength(20);

            builder.Property(v => v.Cidade)
                .HasColumnName("CIDADE")
                .HasMaxLength(100);
        }
    }
}