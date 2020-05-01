using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bmt.Microservices.SnowForecastCenter.Infrastructure;
using Bmt.Microservices.SnowForecastCenter.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bmt.Microservices.SnowForecastCenter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(logging => logging.AddEventSourceLogger());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Configure cross-origin requests (CORS) so consumers can access this API
            services.AddCors(x => x.AddPolicy("Bmt.Microservices.SnowForecastCenterType",
               builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

            // Register custom dependencies
            RegisterDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // Custom security scan middleware component
            app.UseSecurityScan();
        }

        private void RegisterDependencies(IServiceCollection services)
        {
            // Register forecast provider
            services.AddScoped<IForecastProvider, OpenWeatherMapForecast>();
        }
    }
}
