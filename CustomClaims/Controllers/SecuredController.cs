using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;

namespace CustomClaims.Controllers
{
    [Authorize]
    public class SecuredController : Controller
    {
        // GET: Secured
        public ActionResult Index()
        {
            List<Claim> claims = GetCurrentClaimsIdentity().Claims.ToList();
            ViewBag.Claims = claims;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string claim)
        {
            var identity = GetCurrentClaimsIdentity();
            identity.AddClaim(new Claim("http://localhost/identity/CustomCclaims/", claim));

            //Important to reset cookie
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity as ClaimsIdentity);

            return RedirectToAction("Index");
        }

        private static ClaimsIdentity GetCurrentClaimsIdentity()
        {
            return ClaimsPrincipal.Current.Identity as ClaimsIdentity;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
    }
}