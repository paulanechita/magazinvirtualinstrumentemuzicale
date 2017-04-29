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

        public ActionResult Index()
        {
            _afisareProduse.ListaProduse = _produsManager.GetProduse();
            _afisareProduse.CategoriiProduse = _produsManager.GetCategorii();
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
    }
}