using MVIM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVIM.Domain.Interfaces
{
    public interface IUserManager
    {
        bool SaveUser(string nume, string prenume, DateTime dataNasterii, string email, string numarTelefon, string username, string parola);

        bool LoginUser(string username, string parola);

        string ReturnRoleForUser(string user);

        Client GetClientForUsername(int userId);

        List<User> GetUsers();

        bool DeleteUser(string username);
    }
}
