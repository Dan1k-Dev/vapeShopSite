using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonVapeShopAPI.ClassInterface;
using DragonVapeShopAPI.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DragonVapeShopAPI.Database;
using DragonVapeShopAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DragonVapeShopAPI
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
            services.AddMvc();

            #region Подключение сервисов для репозиториев

            services.AddSingleton<IVapesRepository, VapesRepository>();
            services.AddScoped<IVapesRepository, VapesRepository>();
            services.AddScoped<IVapesRepository, VapesRepository>();

            services.AddSingleton<IConsumableRepository, ConsumablesRepository>();
            services.AddScoped<IConsumableRepository, ConsumablesRepository>();
            services.AddScoped<IConsumableRepository, ConsumablesRepository>();

            services.AddSingleton<IOnceVapesRepository, OnceVapesRepository>();
            services.AddScoped<IOnceVapesRepository, OnceVapesRepository>();
            services.AddScoped<IOnceVapesRepository, OnceVapesRepository>();

            services.AddSingleton<ILiquidsRepository, LiquidsRepository>();
            services.AddScoped<ILiquidsRepository, LiquidsRepository>();
            services.AddScoped<ILiquidsRepository, LiquidsRepository>();

            #endregion

            string con = "Server=DESKTOP-CMGFHNU;Database=DragonVape;Trusted_Connection=True;";
            // устанавливаем контекст данных
            services.AddDbContext<ContextDatabase>(options => options.UseSqlServer(con));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            #region Маршрутизация

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "GetsVape",
                    pattern: "GetsVape/{*idVape}",
                    defaults: new { controller = "Vapes", action = "GetVapes" });

                endpoints.MapControllerRoute(
                    name: "GetsConsumables",
                    pattern: "GetsConsumables/{*idConsumable}",
                    defaults: new { controller = "Consumable", action = "GetConsumables" });

                endpoints.MapControllerRoute(
                    name: "GetsLiquids",
                    pattern: "GetsLiquids/{*idLiquid}",
                    defaults: new { controller = "Liquids", action = "GetLiquids" });

                endpoints.MapControllerRoute(
                    name: "GetsOnces",
                    pattern: "GetsOnces/{*idOnceVape}",
                    defaults: new { controller = "OnceVapes", action = "GetOncesVapes" });
            });

            #endregion
        }
    }
}
