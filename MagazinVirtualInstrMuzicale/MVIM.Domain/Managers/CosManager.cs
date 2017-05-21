using MVIM.DAL;
using MVIM.DAL.Repository;
using MVIM.Domain.Interfaces;
using System.Collections.Generic;

namespace MVIM.Domain.Managers
{
    public class CosManager : ICosManager
    {
        private CosRepository _cosRepository = new CosRepository();
        public bool AdaugaProdusInCos(int idProdus, int idClient)
        {
            return _cosRepository.AdaugaProdusInCos(idProdus, idClient);
        }

        public List<Cos> GetCartProducts(int idClient)
        {
            return _cosRepository.GetCartProducts(idClient);
        }

        public bool DeleteProdusDinCos(int idCos)
        {
            return _cosRepository.DeleteProdusDinCos(idCos);
        }

        public bool AdaugaComanda(Adresa adresa, int idClient, IEnumerable<Cos> listaProduse)
        {
            return _cosRepository.AdaugaComanda(adresa, idClient, listaProduse);
        }
    }
}
