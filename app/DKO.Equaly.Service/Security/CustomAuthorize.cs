using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DKO.Equaly.Service.Enum;

namespace DKO.Equaly.Service.Security
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected List<object> _permissions;
        public string UsersConfigKey { get; set; }
        public string RolesConfigKey { get; set; }

        public CustomAuthorize(params object[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Permission)))
                throw new ArgumentException("Permissões");

            this.Roles = string.Join(",", roles.Select(r => System.Enum.GetName(r.GetType(), r)));
            _permissions = roles.ToList();
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if(!base.AuthorizeCore(httpContext))
            {
                //Redirecionar para o login
                new RouteValueDictionary(
                new
                {
                    controller = "Login",
                    action = "Index"
                });

                return false;
            }
            else
            {
                return true;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            new RouteValueDictionary(
                new
                {
                    controller = "NaoAutorizado",
                    action = "AcessoNaoAutorizado"
                });
        }
    }
}
