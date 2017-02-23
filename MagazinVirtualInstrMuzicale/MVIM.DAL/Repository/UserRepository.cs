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
         

        //public UserRepository(MVIMEntities context)
        //{
        //    _context = context;
        //}
        public List<Rol> GetRoles()
        {
            var _context = new MVIMEntities();
            var roles = _context.Rol.ToList();

            return roles;
        }
    }
}
