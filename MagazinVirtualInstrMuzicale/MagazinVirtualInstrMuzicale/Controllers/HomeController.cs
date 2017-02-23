using MVIM.Domain.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinVirtualInstrMuzicale.Controllers
{
    public class HomeController : Controller
    {
        UserManager UserManager = new UserManager();
        // GET: Home
        public ActionResult Index()
        {
            var rol = UserManager.GetRoles();
            return Content(rol.FirstOrDefault().IdRol + " " + rol.FirstOrDefault().Rol1);
        }
    }
}