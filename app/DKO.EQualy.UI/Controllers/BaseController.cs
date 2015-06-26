using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DKO.EQualy.Domain.Entities;
using DKO.Equaly.Service.Security;

namespace DKO.EQualy.UI.Controllers
{
    public class BaseController : Controller
    {
        //protected virtual new CustomPrincipal CustomPrincipal
        //{
        //    get { return HttpContext.User as CustomPrincipal; }
        //}

        protected virtual new CustomPrincipal CustomPrincipal
        {
            get
            {
                if (base.User is CustomPrincipal)
                {
                    return base.User as CustomPrincipal;
                }
                else
                {
                    return new CustomPrincipal(base.User.Identity.Name);
                }
            }
        }

        //protected override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (User != null)
        //    {
        //        if (User.Identity.IsAuthenticated)
        //        {
        //            if (User.Identity is FormsIdentity)
        //            {
        //                FormsIdentity id = base.User.Identity as FormsIdentity;
        //                CustomPrincipal principal = (CustomPrincipal)filterContext.HttpContext.Cache.Get(id.Name);
        //                if (principal == null)
        //                {
        //                    MembershipUser user = Membership.GetUser();

        //                    // Create and populate your Principal object with the needed data and Roles.
        //                    principal = new CustomPrincipal(id, Roles.GetRolesForUser(id.Name).ToList(), user.Email, (Guid)user.ProviderUserKey);
        //                    filterContext.HttpContext.Cache.Add(
        //                    id.Name,
        //                    principal,
        //                    null,
        //                    System.Web.Caching.Cache.NoAbsoluteExpiration,
        //                    new System.TimeSpan(0, 30, 0),
        //                    System.Web.Caching.CacheItemPriority.Default,
        //                    null);
        //                }

        //                filterContext.HttpContext.User = principal;
        //                System.Threading.Thread.CurrentPrincipal = principal;
        //                base.OnAuthorization(filterContext);
        //            }
        //        }
        //    }
        //}
    }
}