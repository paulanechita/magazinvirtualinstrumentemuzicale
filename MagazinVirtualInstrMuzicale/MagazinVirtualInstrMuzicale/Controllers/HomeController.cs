using MagazinVirtualInstrMuzicale.Common;
using MagazinVirtualInstrMuzicale.Models;
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
        private AfisareProduse _afisareProduse = new AfisareProduse();
        private ICosManager _cosManager = new CosManager();

        public ActionResult Index()
        {
            _afisareProduse.ListaProduse = _produsManager.GetProduse();
            _afisareProduse.CategoriiProduse = _produsManager.GetCategorii();

            if (Session["UserLogat"] != null && SuntProduseInCos())
                ViewBag.CandAvemProduseColoratRosu = Constants.BackgroundCos;

            return View(_afisareProduse);
        }

        public ActionResult Filtreaza(int? categoriiFilterParameter)
        {
            _afisareProduse.ListaProduse = _produsManager.GetProduse();
            _afisareProduse.CategoriiProduse = _produsManager.GetCategorii();

            if (categoriiFilterParameter != null)
            {
                _afisareProduse.ListaProduse = _afisareProduse.ListaProduse
                    .Where(c => c.CategorieProdus.FirstOrDefault().IdCategorie == categoriiFilterParameter).ToList();
            }

            return PartialView("_productTablePartialView", _afisareProduse);
        }

        public ActionResult LoadPicture(int id)
        {
            var bytePhoto = _produsManager.ReturnPhotos(id);
            return File(bytePhoto, "image/png");
        }

        [HttpPost]
        public ActionResult AdaugaProdusInCos(int idProdus)
        {
            var user = _userManager.GetUsers().FirstOrDefault(u=>u.UserName == Session["UserLogat"].ToString());
            var client = _userManager.GetClientForUsername(user.IdUser);

            var esteAdaugat = _cosManager.AdaugaProdusInCos(idProdus, client.IdClient);

            if(esteAdaugat)
                ViewBag.CandAvemProduseColoratRosu = Constants.BackgroundCos;

            return Content("");
        }

        private bool SuntProduseInCos()
        {
            var userLogat = Session["UserLogat"].ToString();
            var user = _userManager.GetUsers().Where(u => u.UserName == userLogat).FirstOrDefault();
            var client = _userManager.GetClientForUsername(user.IdUser);

            var produseInCos = _cosManager.GetCartProducts(client.IdClient);

            if (produseInCos.Any())
                return true;
            return false;
        }
    }
}