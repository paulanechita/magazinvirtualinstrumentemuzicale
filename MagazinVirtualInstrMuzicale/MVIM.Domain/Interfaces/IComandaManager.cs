using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVIM.Domain.Interfaces
{
    public interface IComandaManager
    {
        bool ExpediazaComanda(int idComanda, string statusNou);

        void StergeComanda(int idComanda);
    }
}
