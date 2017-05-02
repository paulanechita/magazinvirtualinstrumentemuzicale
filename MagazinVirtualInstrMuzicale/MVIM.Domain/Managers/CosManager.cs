using MVIM.DAL.Repository;
using MVIM.Domain.Interfaces;

namespace MVIM.Domain.Managers
{
    public class CosManager : ICosManager
    {
        private CosRepository _cosRepository = new CosRepository();
        public bool AdaugaProdusInCos(int idProdus, int idClient)
        {
            return _cosRepository.AdaugaProdusInCos(idProdus, idClient);
        }
    }
}
