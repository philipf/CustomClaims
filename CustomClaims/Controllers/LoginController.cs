using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomClaims.Models;

namespace CustomClaims.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        [HttpPost]
        public ActionResult Index(LoginViewModel vm, string returnUrl)
        {
            if (vm.User == "admin" && vm.Password == "admin")
            {
                return Redirect(returnUrl);
            }

            return View();
        }
    }
}