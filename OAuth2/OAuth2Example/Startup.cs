using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAuth2Example.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OAuth2Example
{
   public class Startup
   {
      private readonly IHostingEnvironment env;
      public Startup(IConfiguration configuration, IHostingEnvironment env)
      {
         Configuration = configuration;
         this.env = env;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.Configure<CookiePolicyOptions>(options =>
         {
            // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
         });

         // Get database connection string from secret manager tool secrets in development mode,
         // get from json config file in production mode
         var defaultConnection = env.IsDevelopment()
            ? Configuration["OAuth2ExampleSecrets:DefaultConnection"]
            : Configuration.GetConnectionString("DefaultConnection");

         services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(defaultConnection));

         services.AddDefaultIdentity<IdentityUser>()
             .AddDefaultUI(UIFramework.Bootstrap4)
             .AddEntityFrameworkStores<ApplicationDbContext>();

         // Configure Google OAuth2 Authentication
         services.AddAuthentication()
            .AddGoogle(googleOptions =>
            {
               var googleAuthSection =
                 env.IsDevelopment() ?
                 Configuration.GetSection("OAuth2ExampleSecrets:Authentication:Google")
                 : Configuration.GetSection("Authentication:Google");

               googleOptions.ClientId = googleAuthSection["ClientId"];
               googleOptions.ClientSecret = googleAuthSection["ClientSecret"];
            })
            // Configure Microsoft OAuth2 Authentication
            .AddMicrosoftAccount(microsoftOptions =>
            {
               var msAuthSection =
                 env.IsDevelopment() ?
                 Configuration.GetSection("OAuth2ExampleSecrets:Authentication:Microsoft")
                 : Configuration.GetSection("Authentication:Microsoft");

               microsoftOptions.ClientId = msAuthSection["ClientId"];
               microsoftOptions.ClientSecret = msAuthSection["ClientSecret"];
            })
            // Configure Facebook OAuth2 Authentication
            .AddFacebook(facebookOptions =>
            {
               var facebookAuthSection =
                 env.IsDevelopment() ?
                 Configuration.GetSection("OAuth2ExampleSecrets:Authentication:Facebook")
                 : Configuration.GetSection("Authentication:Facebook");

               facebookOptions.AppId = facebookAuthSection["ClientId"];
               facebookOptions.AppSecret = facebookAuthSection["ClientSecret"];
            })
            // Configure Twitter OAuth2 Authentication
            .AddTwitter(twitterOptions =>
            {
               var twitterAuthSection =
                 env.IsDevelopment() ?
                 Configuration.GetSection("OAuth2ExampleSecrets:Authentication:Twitter")
                 : Configuration.GetSection("Authentication:Twitter");

               twitterOptions.ConsumerKey = twitterAuthSection["ClientId"];
               twitterOptions.ConsumerSecret = twitterAuthSection["ClientSecret"];
            });

         services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
         }
         else
         {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
         }

         app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseCookiePolicy();

         app.UseAuthentication();

         app.UseMvc();
      }
   }
}