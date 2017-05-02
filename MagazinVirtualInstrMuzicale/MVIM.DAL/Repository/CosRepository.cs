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

            if (produsExistent != null)
            {
                var cos = new Cos();

                cos.StatusCos = new StatusCos();
                cos.StatusCos.DescriereStatusCos = "In asteptare.";

                cos.IdClient = idClient; //trebuie trimis si id-ul clientului
                cos.IdCodStatusCos = cos.StatusCos.IdCodStatusCos;
                cos.Data = DateTime.Now;

                cos.CosProdus = new List<CosProdus>();
                cos.CosProdus.Add(new CosProdus { IdCos = cos.IdCos, Cantitate = 1, IdProdus = idProdus });

                _context.Cos.Add(cos);
               
                _context.SaveChanges();

                esteProdusulAdaugat = true;

                return esteProdusulAdaugat;
            }
            return esteProdusulAdaugat;
        }
    }
}
