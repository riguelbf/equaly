using System.Web.Mvc;
using DKO.EQualy.Domain.Interfaces;

namespace DKO.EQualy.UI.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}