using MVIM.DAL.Interfete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVIM.DAL.Repository
{
    public class CosRepository : ICosRepository
    {
        private MVIMEntities _context = new MVIMEntities();

        public bool AdaugaProdusInCos(int idProdus, int idClient)
        {
            var esteProdusulAdaugat = false;
            var produsExistent = _context.Produs.FirstOrDefault(p => p.IdProdus == idProdus);

            var produsExistentInCos = _context.Cos.FirstOrDefault(p => p.IdProdus == idProdus);

            Cos cosExistent = new Cos();
            if (produsExistentInCos != null)
                cosExistent = _context.Cos.Find(produsExistentInCos.IdCos);

            if (produsExistent != null && produsExistentInCos == null)
            {
                var cos = new Cos();

                cos.Cantitate = 1; //un produs
                cos.Data = DateTime.Now;
                cos.IdClient = idClient;
                cos.IdProdus = idProdus;
                cos.Status = "Pending";

                _context.Cos.Add(cos);

                _context.SaveChanges();

                esteProdusulAdaugat = true;

                return esteProdusulAdaugat;
            }
            else if (produsExistentInCos != null && produsExistent != null)
            {
                cosExistent.Cantitate = cosExistent.Cantitate + 1;

                _context.SaveChanges();
            }
            return esteProdusulAdaugat;
        }

        public List<Cos> GetCartProducts(int idClient)
        {
            return _context.Cos.Where(p => p.IdClient == idClient).ToList();

        }

        public bool DeleteProdusDinCos(int idCos)
        {
            var isDeleted = false;
            var cosForDelete = _context.Cos.FirstOrDefault(p => p.IdCos == idCos);

            _context.Cos.Remove(cosForDelete);
            _context.SaveChanges();
            isDeleted = true;
            return isDeleted;
        }
    }
}
