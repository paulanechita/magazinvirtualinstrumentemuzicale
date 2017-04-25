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
        public SesiuneCurenta User = new SesiuneCurenta();
        private IUserManager _userManager = new UserManager();
        private IProdusManager _produsManager = new ProdusManager();
        private static int idProdus;

        //public AdminProduseController(IProdusManager produsManager, IUserManager userManager)
        //{
        //    _produsManager = produsManager;
        //    _userManager = userManager;
        //}
        

        [HttpGet]
        public ActionResult AdaugaProdus()
        {
            var model = GetAdaugaProdusModel();

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

            var model = GetAdaugaProdusModel();

            return View(model);
        }

     
        public ActionResult LoadPicture(int id)
        {
            var bytePhoto = _produsManager.ReturnPhotos(id);
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
            idProdus = id;
            var produsDeEditat = _produsManager.GetProdus(id);
            return View(produsDeEditat);
        }

        [HttpPost]
        public ActionResult EditeazaProdus(MVIM.DAL.Produs produsActualizat)
        {
            var esteActualizat = _produsManager.ActualizeazaProdus(produsActualizat, idProdus);
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

        public ActionResult Users()
        {
            var listaUseri = new List<Models.User>();

            var useri = _userManager.GetUsers();

            foreach (var user in useri)
            {
                var clientForUser = _userManager.GetClientForUsername(user.IdUser);

                listaUseri.Add(
                    new Models.User {
                        Email = clientForUser.Email,
                        NumarDeTelefon = clientForUser.NumarTelefon,
                        Nume = clientForUser.Nume,
                        Prenume = clientForUser.Prenume,
                        Username = user.UserName });
            }
            //TODO: Retrieve users.
            return View(listaUseri);
        }

        public ActionResult Delete(string username)
        {
            var esteSters = _userManager.DeleteUser(username);
            if (esteSters)
            {
                return RedirectToAction("Users");
            }
            else 
                return RedirectToAction("Users");
        }

        private AdaugaProdusModel GetAdaugaProdusModel()
        {
            var model = new AdaugaProdusModel();

            model.CategoriiProduse = _produsManager.GetCategorii();
            model.ProducatoriProduse = _produsManager.GetProducatori();

            return model;
        }
    }
}