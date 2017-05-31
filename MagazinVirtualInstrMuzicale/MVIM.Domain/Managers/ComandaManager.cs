using MVIM.DAL.Interfete;
using MVIM.DAL.Repository;
using MVIM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVIM.Domain.Managers
{
    public class ComandaManager : IComandaManager
    {
        private IComandaRepository _expediazaComandaRepository = new ComandaRepository();

        public bool ExpediazaComanda(int idComanda, string statusNou)
        {
            return _expediazaComandaRepository.ExpediazaComanda(idComanda, statusNou);
        }

        public void StergeComanda(int idComanda)
        {
            _expediazaComandaRepository.StergeComanda(idComanda);
        }
    }
}
