﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVIM.DAL.Interfete
{
    public interface ICosRepository
    {
        bool AdaugaProdusInCos(int idProdus, int idClient);

        List<Cos> GetCartProducts(int idClient);

        bool DeleteProdusDinCos(int idCos);

        bool AdaugaComanda(Adresa adresa, int idClient, IEnumerable<Cos> listaProduse);
    }
}
