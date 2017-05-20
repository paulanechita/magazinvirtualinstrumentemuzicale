using MagazinVirtualInstrMuzicale.Common;
using MagazinVirtualInstrMuzicale.Models;
using MVIM.Domain.Interfaces;
using MVIM.Domain.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult FinalizeazaComanda()
        {
            return View();
        }
    }
}