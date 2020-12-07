using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TDJ.Data.Interfaces;
using TDJ.Data.Repositorios;
using TDJ.Servicos.Interfaces;
using TDJ.Servicos.Servicos;

namespace TDJ.MVC.Configuracoes
{
    public static class ConfiguracoesDeInjecaoDeDependencia
    {
        public static void RegistrarInjecoesDeDependencias(this IServiceCollection services)
        {
            services.AddScoped<IRepositorioDeProduto, RepositorioDeProduto>();
            services.AddScoped<IRepositorioDeCliente, RepositorioDeCliente>();

            services.AddScoped<IServicosDeAPIDeCliente, ServicosDeAPIDeCliente>();
            services.AddScoped<IServicosDeAPIDeProduto, ServicosDeAPIDeProduto>();

            services.AddHttpClient<IServicosDeProduto, ServicosDeProduto>();
            services.AddHttpClient<IServicosDeCliente, ServicosDeCliente>();
            

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
