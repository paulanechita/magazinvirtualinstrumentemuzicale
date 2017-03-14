﻿using MVIM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVIM.Domain.Interfaces
{
    public interface IProdusManager
    {
        bool AdaugaProdus(string descriereProdus, decimal pretProdus, string numeProdus, byte[] poza, int idCategorie, int idProducator);

        byte[] ReturnPhotos();

        List<Categorie> GetCategorii();

        List<Producator> GetProducatori();

        Categorie GetCategorieById(int id);

        void AdaugaCategorieNoua(string numeCategorie);

        void AdaugaProducatorNou(string numeProducator);

        List<Produs> GetProduse();
    }
}
