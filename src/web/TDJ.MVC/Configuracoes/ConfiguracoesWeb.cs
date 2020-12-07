using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TDJ.Dominio.Extensions;

namespace TDJ.MVC.Configuracoes
{
    public static class ConfiguracoesWeb
    {
        public static void AddConfiguracoesWeb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
            services.Configure<AppSettings>(configuration);

            services.AddCors(opt =>
            {
                opt.AddPolicy("Total",
                    builder =>
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader());
            });
        }
        public static void UseConfiguracoesWeb(this IApplicationBuilder app, IWebHostEnvironment env)
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
