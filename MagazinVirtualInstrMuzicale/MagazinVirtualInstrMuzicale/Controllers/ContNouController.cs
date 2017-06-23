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
    public class ContNouController : Controller
    {
        private IUserManager _userManager = new UserManager();

        //public ContNouController(IUserManager userManager)
        //{
        //    _userManager = userManager;
        //}

        [HttpGet]
        public ActionResult InregistrareUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InregistrareUser(ContNouModel userNou)
        {
            if (ModelState.IsValid)
            {
                if (userNou.Parola == userNou.ConfirmaParola)
                {
                    var isSaved = _userManager.SaveUser(userNou.Nume, userNou.Prenume, userNou.DataNasterii, userNou.Email, userNou.NumarTelefon, userNou.Username, userNou.Parola);
                    if (isSaved)
                        return RedirectToAction("Login", "Login");
                    else
                        return View();
                }
                else
                    return View();
            }
            return View();
        }
    }
}