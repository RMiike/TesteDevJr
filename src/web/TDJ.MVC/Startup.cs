using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDJ.MVC.Configuracoes;

namespace TDJ.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfiguracoesWeb(Configuration);
            services.AddConfiguracoesDbContext(Configuration);
            services.RegistrarInjecoesDeDependencias();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseConfiguracoesWeb(env);
        }
    }
}
