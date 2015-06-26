using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DKO.EQualy.UI.Controllers
{
    public class AcaoPreventivaController : BaseController
    {
        public ActionResult Index()
        {
            return View("AcaoPreventiva");
        }
	}
}