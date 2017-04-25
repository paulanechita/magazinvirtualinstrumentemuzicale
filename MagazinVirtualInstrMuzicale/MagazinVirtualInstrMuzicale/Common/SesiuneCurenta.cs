using MVIM.Domain.Interfaces;
using MVIM.Domain.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinVirtualInstrMuzicale.Common
{
    public class SesiuneCurenta : Controller
    {
        //private IUserManager _userManager;

        //public SesiuneCurenta(IUserManager userManager) : base()
        //{
        //    _userManager = userManager;
        //}
        private IUserManager _userManager = new UserManager();

        public SesiuneCurenta()
        {
        }
        public string GetSesiune()
        {
            var userLogat = Session["UserLogat"].ToString();

            //TODO: modificare pe viitor
            var role = _userManager.ReturnRoleForUser(userLogat);

            if (role!=null)
            {
                return userLogat;
            }
            return null;
        }

    }
}
