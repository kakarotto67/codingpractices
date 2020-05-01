using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Bmt.Microservices.SnowForecastCenter.Middleware
{
   public class SecurityScan
   {
      private readonly RequestDelegate next;
      private readonly string apiKeyQueryParameter = "appid";

      public SecurityScan(RequestDelegate next)
      {
         this.next = next;
      }

      public async Task Invoke(HttpContext context)
      {
         // Request logic
         if (!context.Request.Query.ContainsKey(apiKeyQueryParameter))
         {
            throw new AuthenticationException();
         }

         await next.Invoke(context);

         // Response logic
      }
   }

   public static class SecurityScanExtensions
   {
      public static IApplicationBuilder UseSecurityScan(this IApplicationBuilder app)
      {
         return app.UseMiddleware<SecurityScan>();
      }
   }
}