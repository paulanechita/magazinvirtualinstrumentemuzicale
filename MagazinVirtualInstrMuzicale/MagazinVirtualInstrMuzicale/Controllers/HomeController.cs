using MagazinVirtualInstrMuzicale.Common;
using MVIM.Domain.Interfaces;
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
        private SesiuneCurenta _user = new SesiuneCurenta();
        private IUserManager _userManager = new UserManager();
        private IProdusManager _produsManager = new ProdusManager();


        public ActionResult Index()
        {
            var produse = _produsManager.GetProduse();
            return View(produse);
        }

        public ActionResult LoadPicture(int id)
        {
            var bytePhoto = _produsManager.ReturnPhotos(id);
            return File(bytePhoto, "image/png");
        }
    }
}