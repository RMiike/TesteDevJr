using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDJ.Dominio.Entidades;

namespace TDJ.Repositorio.Mapeamentos
{
    public class ClienteMapeamento : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .HasColumnType("varchar(250)")
                   .IsRequired();

            builder.Property(c => c.CPF)
                   .HasColumnType("varchar(250)")
                   .IsRequired();

            builder.Property(c => c.Email)
                   .HasColumnType("varchar(250)")
                   .IsRequired();

        }
    }
}
