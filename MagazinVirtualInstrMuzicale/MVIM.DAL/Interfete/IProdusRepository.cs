﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVIM.DAL.Interfete
{
    public interface IProdusRepository
    {
        bool AdaugaProdus(string descriereProdus, decimal pretProdus, string numeProdus, byte[] poza, int idCategorie, int idProducator);

        byte[] ReturnPhotos(); //testing

        List<Categorie> GetCategorii();

        List<Producator> GetProducatori();

        Categorie GetCategorieById(int id);

        void AdaugaCategorieNoua(string numeCategorie);

        void AdaugaProducatorNou(string numeProducator);

        List<Produs> GetProduse();

        Produs GetProdus(int id);

        bool ActualizeazaProdus(Produs produsActualizat, int idProdus);

        bool StergeProdus(int id);
    }
}