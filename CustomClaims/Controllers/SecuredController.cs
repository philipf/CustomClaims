using System.Web.Mvc;

namespace CustomClaims.Controllers
{
    [Authorize]
    public class SecuredController : Controller
    {
        // GET: Secured
        public ActionResult Index()
        {
            return View();
        }
    }
}