using Microsoft.EntityFrameworkCore;
using System.Linq;
using TDJ.Dominio.Entidades;
using TDJ.Dominio.Interfaces;

namespace TDJ.Repositorio.Contexto
{
    public class TDJDbContext : DbContext, IUnidadeDeServico
    {

        public TDJDbContext(DbContextOptions<TDJDbContext> opt) : base(opt) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }



        protected override void OnModelCreating(ModelBuilder model)
        {
            foreach( var property in model.Model.GetEntityTypes().SelectMany(
               e => e.GetProperties().Where(p => p.ClrType == typeof(string))) )
                property.SetColumnType("varchar(100)");

            model.ApplyConfigurationsFromAssembly(typeof(TDJDbContext).Assembly);
        }
        public bool Commit()
        {
            return base.SaveChanges() > 0;
        }
    }
}
