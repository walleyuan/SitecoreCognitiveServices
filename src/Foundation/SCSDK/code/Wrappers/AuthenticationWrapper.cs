using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Security.Accounts;
using Sitecore.Security.Authentication;
using Sitecore.Web.Authentication;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Wrappers
{
    public interface IAuthenticationWrapper
    {
        void Logout();
        bool IsCurrentUserAdministrator();
        User GetCurrentUser();
        List<DomainAccessGuard.Session> GetDomainAccessSessions();
        void Kick(string sessionId);
    }

    public class AuthenticationWrapper : IAuthenticationWrapper
    {
        public void Logout()
        {
            AuthenticationManager.Logout();
        }

        public bool IsCurrentUserAdministrator()
        {
            return Sitecore.Context.User.IsAdministrator;
        }

        public User GetCurrentUser()
        {
            return Sitecore.Context.User;
        }

        public List<DomainAccessGuard.Session> GetDomainAccessSessions()
        {
            return DomainAccessGuard.Sessions;
        }

        public void Kick(string sessionId)
        {
            DomainAccessGuard.Kick(sessionId);
        }
    }
}