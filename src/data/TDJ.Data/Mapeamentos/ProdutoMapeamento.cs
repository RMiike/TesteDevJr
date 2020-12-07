using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDJ.Dominio.Entidades;

namespace TDJ.Repositorio.Mapeamentos
{
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .HasColumnType("varchar(250)")
                   .IsRequired();

            builder.Property(c => c.Ativo)
                   .HasDefaultValue(true);

            builder.Ignore(c => c.IdDoCliente);


            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.ErrorMessages);
        }
    }
}
