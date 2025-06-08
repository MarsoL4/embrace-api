namespace Embrace.API.Infrastructure.Mappings
{
    using Embrace.API.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OngMapping : IEntityTypeConfiguration<Ong>
    {
        public void Configure(EntityTypeBuilder<Ong> builder)
        {
            builder.ToTable("ONGS");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(o => o.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(o => o.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(o => o.Cnpj)
                .HasColumnName("CNPJ")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(o => o.Telefone)
                .HasColumnName("TELEFONE")
                .HasMaxLength(20);
        }
    }
}