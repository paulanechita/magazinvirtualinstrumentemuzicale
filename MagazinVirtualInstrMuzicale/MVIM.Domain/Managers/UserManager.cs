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
        public IUserRepository UserRepository = new UserRepository();
        public List<Rol> GetRoles()
        {
            return UserRepository.GetRoles();
        }
    }
}
