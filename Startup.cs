using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Salvus.Data;
using Salvus.Services;

namespace Salvus
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Console.WriteLine("STARTUP");


            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("CONFIGURE SERVICES");

            services.AddDbContext<SalvusContextDb>
            (
                options => options.UseSqlServer
                (
                    Configuration.GetConnectionString("TestingDatabaseConnection")
                )
            );

            // setup automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Dependency Injections
            services.AddScoped<ISalvusRepo, SalvusRepo>();

            services.AddControllersWithViews();

            services.AddHostedService<CoinUpdaterService>();

            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Console.WriteLine($"ENVIORMENT: {env.EnvironmentName}");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
