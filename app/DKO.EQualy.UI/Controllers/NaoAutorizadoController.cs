using System.Web.Mvc;

namespace DKO.EQualy.UI.Controllers
{
    public class NaoAutorizadoController : BaseController
    {
        //
        // GET: /NaoAutorizado/
        public ActionResult AcessoNaoAutorizado()
        {
            return View();
        }
	}
}