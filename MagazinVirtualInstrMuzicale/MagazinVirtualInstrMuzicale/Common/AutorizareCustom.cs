﻿using MVIM.Domain.Interfaces;
using MVIM.Domain.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinVirtualInstrMuzicale.Common
{
    public class AutorizareAdministratorCustom : System.Web.Mvc.AuthorizeAttribute
    {
        //private IUserManager _userManager;
        //public AutorizareAdministratorCustom(IUserManager userManager)
        //{
        //    _userManager = userManager;
        //}

        private IUserManager _userManager = new UserManager(); 
        
        public AutorizareAdministratorCustom() : base()
        {
        }
        public string Sesiune;
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (UserLoggedIn())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool UserLoggedIn()
        {
            
            var currentSession = HttpContext.Current.Session;
            if (currentSession["UserLogat"] == null)
            {
                return false;
            }
            var userLogat = currentSession["UserLogat"].ToString();
            //TODO: modificare pe viitor
            var role = _userManager.ReturnRoleForUser(userLogat).ToLower();

            if (role == "administrator")
            {
                return true;
            }
            return false;
        }
    }
}