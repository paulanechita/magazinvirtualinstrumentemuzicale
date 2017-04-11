using MagazinVirtualInstrMuzicale.Common;
using MagazinVirtualInstrMuzicale.Models;
using MVIM.DAL;
using MVIM.Domain.Interfaces;
using MVIM.Domain.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinVirtualInstrMuzicale.Controllers
{
    [AutorizareAdministratorCustom]
    public class AdminProduseController : Controller
    {

        private IUserManager _userManager = new UserManager();
        private IProdusManager _produsManager = new ProdusManager();

        public SesiuneCurenta User = new SesiuneCurenta();
        
        // GET: AdminProduse
        [HttpGet]
        public ActionResult AdaugaProdus()
        {
            var model = new AdaugaProdusModel();

            model.CategoriiProduse = _produsManager.GetCategorii();
            model.ProducatoriProduse = _produsManager.GetProducatori();

            return View(model);
        }

        [HttpPost]
        public ActionResult AdaugaProdus(Models.Produs produsNou, int IdCategorieProdusSelectata,int IdProducatorProdusSelectat)
        {
            byte[] pozaArray;
            using (Stream inputStream = produsNou.Upload.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                pozaArray = memoryStream.ToArray();
            }

            var categorieProdus = _produsManager.GetCategorieById(IdCategorieProdusSelectata);


            var isSaved = _produsManager.AdaugaProdus(
                produsNou.Descriere,
                (decimal)produsNou.Pret, 
                produsNou.Nume, 
                pozaArray,
                IdCategorieProdusSelectata,
                IdProducatorProdusSelectat
                );




            return View();
        }

        //test
        public ActionResult LoadPicture()
        {
            var bytePhoto = _produsManager.ReturnPhotos();
            return File(bytePhoto, "image/png");
        }

        public ActionResult OperatiuniProduse()
        {
            return View();
        }

        public ActionResult AdaugaCategorie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdaugaCategorie(string NumeCategorie)
        {
            _produsManager.AdaugaCategorieNoua(NumeCategorie);
            return View();
        }

        public ActionResult AdaugaProducator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdaugaProducator(string NumeProducator)
        {
            _produsManager.AdaugaProducatorNou(NumeProducator);
            return View();
        }

        public ActionResult AfisareProduse()
        {
            var produse = _produsManager.GetProduse();
            return View(produse);
        }

        [HttpGet]
        public ActionResult EditeazaProdus(int id)
        {
            var produsDeEditat = _produsManager.GetProdus(id);
            return View(produsDeEditat);
        }

        [HttpPost]
        public ActionResult EditeazaProdus(MVIM.DAL.Produs produsActualizat)
        {
            var esteActualizat = _produsManager.ActualizeazaProdus(produsActualizat);
            if (esteActualizat)
            {
                return RedirectToAction("AfisareProduse");
            }
            return View();
        }

        public ActionResult StergeProdus(int id)
        {
            var aFostSters = _produsManager.StergeProdus(id);
            if (aFostSters)
            {
                return RedirectToAction("AfisareProduse");
            }
            return RedirectToAction("AfisareProduse");
        }

    }
}