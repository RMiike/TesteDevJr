using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TDJ.Data.Interfaces;
using TDJ.Data.Repositorios;
using TDJ.Repositorio.Contexto;
using TDJ.Servicos.Interfaces;
using TDJ.Servicos.Servicos;

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
            services.AddControllersWithViews();

            services.AddDbContext<TDJDbContext>(opt =>
               opt.UseSqlServer(Configuration.GetConnectionString("TDJConnection")));

            services.AddScoped<TDJDbContext>();
            services.AddScoped<IRepositorioDeProduto, RepositorioDeProduto>();

            services.AddHttpClient<IServicosDeProduto, ServicosDeProduto>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddCors(opt =>
            {
                opt.AddPolicy("Total",
                    builder =>
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("Total");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
