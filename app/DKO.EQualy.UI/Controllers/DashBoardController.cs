using System.Web.Mvc;

namespace DKO.EQualy.UI.Controllers
{
    public class DashBoardController : BaseController
    {
        public ActionResult Index()
        {
            return View("DashBoard");
        }
	}
}