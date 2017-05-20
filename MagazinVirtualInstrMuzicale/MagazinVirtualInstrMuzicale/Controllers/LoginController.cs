using MagazinVirtualInstrMuzicale.Models;
using MVIM.Domain.Interfaces;
using MVIM.Domain.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MagazinVirtualInstrMuzicale.Controllers
{
    public class LoginController : Controller
    {
        //private IUserManager _userManager;

        //public LoginController(IUserManager userManager)
        //{
        //    _userManager = userManager;
        //}
        private IUserManager _userManager = new UserManager();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel userToLogIn)
        {
            var isLoggedIn = _userManager.LoginUser(userToLogIn.Username, userToLogIn.Parola);

            if (isLoggedIn)
            {
                Session["UserLogat"] = userToLogIn.Username;
                var userRole = _userManager.ReturnRoleForUser(userToLogIn.Username);
                Session["UserRole"] = userRole;
                return RedirectToAction("Index", "Home");
            }
                return View();
        }
    }
}