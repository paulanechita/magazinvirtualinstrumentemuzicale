using MagazinVirtualInstrMuzicale.Common;
using MagazinVirtualInstrMuzicale.Models;
using MVIM.DAL;
using MVIM.Domain.Interfaces;
using MVIM.Domain.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MagazinVirtualInstrMuzicale.Controllers.Client
{
    public class ClientController : Controller
    {
        private SesiuneCurenta _user = new SesiuneCurenta();
        private IUserManager _userManager = new UserManager();
        private IProdusManager _produsManager = new ProdusManager();
        private AfisareProduse _afisareProduse = new AfisareProduse();
        private ICosManager _cosManager = new CosManager();

        // GET: Client
        public ActionResult Cos()
        {
            var userLogat = Session["UserLogat"].ToString();
            var user = _userManager.GetUsers().Where(u => u.UserName == userLogat).FirstOrDefault();
            var client = _userManager.GetClientForUsername(user.IdUser);

            var produseInCos = _cosManager.GetCartProducts(client.IdClient);

            if (produseInCos.Any())
                ViewBag.CandAvemProduseColoratRosu = Constants.BackgroundCos;

            return View(produseInCos);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }

        public ActionResult Delete(int idCos)
        {
            _cosManager.DeleteProdusDinCos(idCos);

            return RedirectToAction("Cos");
        }

        [HttpGet]
        public ActionResult FinalizeazaComanda()
        {
            var userLogat = Session["UserLogat"].ToString();
            var user = _userManager.GetUsers().Where(u => u.UserName == userLogat).FirstOrDefault();
            var client = _userManager.GetClientForUsername(user.IdUser);

            var listaProduseInCos = _cosManager.GetCartProducts(client.IdClient);

            var model = new FinalizareComandaModel();
            model.ListaProduseInCos = listaProduseInCos;

            return View(model);
        }

        [HttpPost]
        public ActionResult FinalizeazaComanda(FinalizareComandaModel finalizeazaComanda)
        {
            var userLogat = Session["UserLogat"].ToString();
            var user = _userManager.GetUsers().Where(u => u.UserName == userLogat).FirstOrDefault();
            var client = _userManager.GetClientForUsername(user.IdUser);

            var listaProduseInCos = _cosManager.GetCartProducts(client.IdClient);

            var sb = new StringBuilder();

            decimal total = 0;

            foreach (var produs in listaProduseInCos)
            {
                sb.Append(Environment.NewLine);
                sb.Append("Denumire Produs: " + produs.Produs.NumeProdus + "  , " + "Cantitate: " + produs.Cantitate + "  , " + "Pret: " + produs.Produs.PretProdus * produs.Cantitate);
                total = total + produs.Produs.PretProdus;
            }

            sb.Append(Environment.NewLine);
            sb.Append("TOTAL: " + total.ToString("#.##") + "RON");
            sb.Append(Environment.NewLine);
            sb.Append("Produsele vor fi expediate la adresa: ");
            sb.Append(Environment.NewLine);
            sb.Append("Strada: " + finalizeazaComanda.Strada + " , " + "Numar: " + finalizeazaComanda.Numar);
            sb.Append(Environment.NewLine);
            sb.Append("Oras: " + finalizeazaComanda.Oras + " , " + "Cod postal: " + finalizeazaComanda.CodPostal + ", " + finalizeazaComanda.Tara);
            sb.Append(Environment.NewLine);
            sb.Append("Produsele va for fi livrate in data de: " + DateTime.Now.AddDays(3));
            sb.Append(Environment.NewLine);
            sb.Append("Va multumim!");

            var emailBody = sb.ToString();

            var adresa = new Adresa()
            {
                Strada = finalizeazaComanda.Strada,
                CodPostal = finalizeazaComanda.CodPostal,
                Judet = finalizeazaComanda.Judet,
                Numar = finalizeazaComanda.Numar.ToString(),
                Oras = finalizeazaComanda.Oras
            };

            var esteComandaAdaugata = _cosManager.AdaugaComanda(adresa, client.IdClient, listaProduseInCos);

            if (esteComandaAdaugata)
            {
                EmailHelper.SendEmail(
                Constants.EmailFrom,
                client.Email,
                Constants.FromName,
                Constants.EmailTimeStamp + DateTime.Now,
                emailBody);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}