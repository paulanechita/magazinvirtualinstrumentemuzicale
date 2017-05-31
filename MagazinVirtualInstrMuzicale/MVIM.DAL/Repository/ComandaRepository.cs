using MVIM.DAL.Interfete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVIM.DAL.Repository
{
    public class ComandaRepository : IComandaRepository
    {
        private MVIMEntities _context = new MVIMEntities();

        public bool ExpediazaComanda(int idComanda, string statusNou)
        {
            var statusSchimbat = false;

            var comanda = _context.Comanda.Where(c => c.IdComanda == idComanda).FirstOrDefault();
            if (comanda != null)
                comanda.StatusComanda.DescriereStatusComanda = statusNou;

            _context.SaveChanges();

            statusSchimbat = true;

            return statusSchimbat;
        }

        public void StergeComanda(int idComanda)
        {
            var comandaDeSters = _context.Comanda.Where(c => c.IdComanda == idComanda).FirstOrDefault();

            if (comandaDeSters != null)
            {

                if (comandaDeSters.ComandaProdus != null)
                {
                    foreach (var comandaProdus in comandaDeSters.ComandaProdus.ToList())
                    {
                        _context.ComandaProdus.Remove(comandaProdus);
                    }
                }
                _context.Comanda.Remove(comandaDeSters);

                if (comandaDeSters.StatusComanda != null)
                    _context.StatusComanda.Remove(comandaDeSters.StatusComanda);

                if (comandaDeSters.Adresa != null)
                    _context.Adresa.Remove(comandaDeSters.Adresa);

                _context.SaveChanges();
            }
        }
    }
}
