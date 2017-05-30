using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVIM.DAL.DataModels
{
    public class ComenziPlasateDataModel
    {
        public List<Comanda> ListaComenzi { get; set; }

        public List<ComandaProdus> ListaProduseComandate { get; set; }
    }
}
