using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Infra.IOC;
using DKO.Equaly.Service.Security;
using DKO.EQualy.UI.Models;
using Newtonsoft.Json;

namespace DKO.EQualy.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Ioc.Init();
            DependencyResolver.SetResolver(new IocDependencyResolver());
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null) return;

            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            if (authTicket == null) return;

            var deserializeUser = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(authTicket.UserData);
            var customPrincipal = new CustomPrincipal(authTicket.Name)
            {
                Nome = deserializeUser.Nome,
                Sobrenome = deserializeUser.Sobrenome,
                Roles = deserializeUser.Roles,
                UsuarioId = deserializeUser.UsuarioId
            };

            HttpContext.Current.User = customPrincipal;
        }
    }
}
