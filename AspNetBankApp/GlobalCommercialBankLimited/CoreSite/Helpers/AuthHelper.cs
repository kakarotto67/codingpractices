using System;
using System.Web;
using System.Web.Security;
using GCBL.CoreSite.Managers;
using GCBL.Shared.Helpers;

namespace GCBL.CoreSite.Helpers
{
    public static class AuthHelper
    {
        private static readonly UserAccountManager UserAccountManager;

        static AuthHelper()
        {
            UserAccountManager = new UserAccountManager();
        }

        public static bool IsValidUser(string name, string password)
        {
            return UserAccountManager.CheckIfUserValid(name, password);
        }

        public static bool TryRegisterUserAccount(string name, string password)
        {
            return UserAccountManager.RegisterNewUserAccount(name, password.Encrypt());
        }

        public static bool IsUserAuthenticated(HttpContextBase context)
        {
            return UserAccountManager.CheckIfUserExists(GetAuthenticatedUserName(context));
        }

        public static string GetAuthenticatedUserName(HttpContextBase context)
        {
            var httpCookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (httpCookie == null)
            {
                return String.Empty;
            }
            var formsAuthenticationTicket = FormsAuthentication.Decrypt(httpCookie.Value);
            return formsAuthenticationTicket != null ? formsAuthenticationTicket.Name : String.Empty;
        }
    }
}