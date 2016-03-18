using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using CustomClaims.Models;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;

namespace CustomClaims.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel vm, string returnUrl)
        {
            if (!(vm.User == "admin" && vm.Password == "admin"))
                return View();

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, vm.User));
            var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, id);

            return Redirect(returnUrl);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
    }
}