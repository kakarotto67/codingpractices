using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using CarrotSender.MessageBus.RabbitMq;
using CarrotSender.Business.Abstracts;
using CarrotSender.Business.Managers;

namespace CarrotSender.Web
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
            // Setup RabbitMQ client
            var connectionFactory = new ConnectionFactory
            {
                HostName = Configuration.GetValue<String>("MessageBusSettings:Connection:HostName"),
                Port = Configuration.GetValue<Int32>("MessageBusSettings:Connection:Port"),
                VirtualHost = Configuration.GetValue<String>("MessageBusSettings:Connection:VirtualHost"),
                UserName = Configuration.GetValue<String>("MessageBusSettings:Connection:UserName"),
                Password = Configuration.GetValue<String>("MessageBusSettings:Connection:Password")
            };
            services.AddSingleton<IConnectionFactory>(sp => connectionFactory);

            // Setup Message Bus
            services.AddSingleton<RabbitMqBus>();

            services.AddScoped<ISenderManager, JsonSenderManager>();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}