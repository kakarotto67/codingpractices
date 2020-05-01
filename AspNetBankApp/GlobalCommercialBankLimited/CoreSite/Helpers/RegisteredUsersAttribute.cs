using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GCBL.CoreSite.Helpers
{
    internal class RegisteredUsersAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext) && AuthHelper.IsUserAuthenticated(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
                return;
            }

            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
            {
                {"Controller", "Account"},
                {"Action", "Login"}
            });
            filterContext.HttpContext.Response.StatusCode = 403;
        }

        private void Test()
        {
            var connection = new SqlConnection();

            var command = new SqlCommand("SELECT * FROM Dogs1 WHERE Name LIKE @Name", connection);
            command.Parameters.Add(new SqlParameter("Name", "Rex"));
        }
    }
}