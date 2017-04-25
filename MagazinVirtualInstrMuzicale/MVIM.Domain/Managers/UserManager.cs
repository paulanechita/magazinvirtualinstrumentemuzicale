using System;
using System.Collections.Generic;
using MVIM.DAL;
using MVIM.Domain.Interfaces;
using MVIM.DAL.Interfete;
using MVIM.DAL.Repository;

namespace MVIM.Domain.Managers
{
    public class UserManager : IUserManager
    {
        //private IUserRepository _repository;

        //public UserManager(IUserRepository userRepository)
        //{
        //    _repository = userRepository;
        //}

        private UserRepository _repository = new UserRepository();

        public bool LoginUser(string username, string parola)
        {
            return _repository.LoginUser(username, parola);
        }

        public bool SaveUser(string nume, string prenume, DateTime dataNasterii, string email, string numarTelefon, string username, string parola)
        {
            return _repository.SaveUser(nume, prenume, dataNasterii, email, numarTelefon, username, parola);
        }

        public string ReturnRoleForUser(string user)
        {
            return _repository.ReturnRoleForUser(user);
        }

        public Client GetClientForUsername(int userId)
        {
            return _repository.GetClientForUsername(userId);
        }

        public List<User> GetUsers()
        {
            return _repository.GetUsers();
        }

        public bool DeleteUser(string username)
        {
            return _repository.DeleteUser(username);
        }
    }
}
