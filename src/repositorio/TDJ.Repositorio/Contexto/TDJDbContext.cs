using Microsoft.EntityFrameworkCore;
using TDJ.Dominio.Entidades;

namespace TDJ.Repositorio.Contexto
{
    public class TDJDbContext : DbContext
    {
        public TDJDbContext(DbContextOptions<TDJDbContext> opt) : base(opt) { }

        public DbSet<Cliente> MyProperty { get; set; }
    }
}
