using MVIM.DAL.Interfete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVIM.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        MVIMEntities _context = new MVIMEntities();

        public bool LoginUser(string username, string parola)
        {
            var isUserLogged = false;

            var user = _context.User.Where(x => x.UserName == username && x.Parola == parola).FirstOrDefault();

            if (user != null)
            {
                isUserLogged = true;
            }
            return isUserLogged;
        }

        public bool SaveUser(string nume, string prenume, DateTime dataNasterii, string email, string numarTelefon, string username, string parola)
        {
            var isSaved = false;
            try
            {
                var userDeInregistrat = new User();
                userDeInregistrat.UserName = username;
                userDeInregistrat.Parola = parola;
                userDeInregistrat.IdRol = 2;

                _context.User.Add(userDeInregistrat);
                _context.SaveChanges();

                var userId = _context.User.Where(x => x.UserName == username).FirstOrDefault().IdUser;
                var clientDeInregistrat = new Client();
                clientDeInregistrat.Nume = nume;
                clientDeInregistrat.Prenume = prenume;
                clientDeInregistrat.DataNasterii = dataNasterii;
                clientDeInregistrat.Email = email;
                clientDeInregistrat.NumarTelefon = numarTelefon;
                clientDeInregistrat.IdUser = userId;

                _context.Client.Add(clientDeInregistrat);
                _context.SaveChanges();
                isSaved = true;

                return isSaved;
            }
            catch (Exception ex)
            {
                // Loghezi exceptia in db
                throw;
            }
        }

    }
}
