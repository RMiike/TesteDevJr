using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDJ.Repositorio.Contexto;

namespace TDJ.MVC.Configuracoes
{
    public static class ConfiguracoesDeBancoDeDados
    {
        public static void AddConfiguracoesDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TDJDbContext>(opt =>
             opt.UseSqlServer(configuration.GetConnectionString("TDJConnection")));

            services.AddScoped<TDJDbContext>();
        }

    }
}