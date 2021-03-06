﻿using MVIM.DAL.DataModels;
using MVIM.DAL.Interfete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVIM.DAL.Repository
{
    public class ProdusRepository : IProdusRepository
    {
        //private MVIMEntities _context;
        //public ProdusRepository(MVIMEntities context)
        //{
        //    _context = context;
        //}

        private MVIMEntities _context = new MVIMEntities();

        public bool AdaugaProdus(string descriereProdus, decimal pretProdus, string numeProdus, byte[] poza, int idCategorie, int idProducator)
        {
            try
            {
                var isSaved = false;

                _context.Produs.Add(new Produs { IdProducator = idProducator, NumeProdus = numeProdus, PretProdus = pretProdus, DescriereProdus = descriereProdus });
                _context.SaveChanges();

                var idProdus = _context.Produs.Where(x => x.NumeProdus == numeProdus).FirstOrDefault().IdProdus;
                _context.CategorieProdus.Add(new CategorieProdus { IdProdus = idProdus, IdCategorie = idCategorie });
                _context.SaveChanges();

                _context.PozaProdus.Add(new PozaProdus { Poza = poza, IdProdus = idProdus });
                _context.SaveChanges();

                isSaved = true;

                return isSaved;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public byte[] ReturnPhotos(int id)
        {
            var photo = _context.PozaProdus.FirstOrDefault(x => x.IdPozaProdus == id).Poza;
            return photo;
        }

        public List<Categorie> GetCategorii()
        {
            return _context.Categorie.OrderBy(x => x.NumeCategorie).ToList();
        }

        public List<Producator> GetProducatori()
        {
            return _context.Producator.OrderBy(x => x.Nume).ToList();
        }

        public Categorie GetCategorieById(int id)
        {
            var categorie = _context.Categorie.Where(cat => cat.IdCategorie == id).FirstOrDefault();
            if (categorie != null)
            {
                return categorie;
            }
            else
                return new Categorie();
        }

        public void AdaugaCategorieNoua(string numeCategorie)
        {
            _context.Categorie.Add(new Categorie { NumeCategorie = numeCategorie });
            _context.SaveChanges();
        }

        public void AdaugaProducatorNou(string numeProducator)
        {
            _context.Producator.Add(new Producator { Nume = numeProducator });
            _context.SaveChanges();
        }

        public List<Produs> GetProduse()
        {
            var produse = _context.Produs.OrderBy(x => x.NumeProdus).ToList();

            return produse;

        }

        public Produs GetProdus(int id)
        {
            return _context.Produs.Where(x => x.IdProdus == id).FirstOrDefault();
        }

        public bool ActualizeazaProdus(Produs produsActualizat, int idProdus)
        {
            var esteActualizat = false;

            var produsDeActualizat = _context.Produs.Find(idProdus);

            if (produsDeActualizat != null)
            {
                produsDeActualizat.NumeProdus = produsActualizat.NumeProdus;
                produsDeActualizat.PretProdus = produsActualizat.PretProdus;
                produsDeActualizat.DescriereProdus = produsActualizat.DescriereProdus;

                _context.SaveChanges();
                esteActualizat = true;
            }

            return esteActualizat;
        }

        public bool StergeProdus(int id)
        {            
            var aFostSters = false;
            var produsPentruSters = _context.Produs.FirstOrDefault(x => x.IdProdus == id);

            if (produsPentruSters != null)
            {
                var categorieProdus = _context.CategorieProdus.FirstOrDefault(x => x.IdProdus == id);
                if (categorieProdus != null)
                    _context.CategorieProdus.Remove(categorieProdus);
                _context.SaveChanges();

                var pozaProdus = _context.PozaProdus.FirstOrDefault(x => x.IdProdus == id);
                if (pozaProdus != null)
                    _context.PozaProdus.Remove(pozaProdus);
                _context.SaveChanges();



                _context.Produs.Remove(produsPentruSters);
                _context.SaveChanges();
                aFostSters = true;
            }
            return aFostSters;
        }

        public bool StergeCategorie(int idCategorie)
        {
            var isDeleted = false;
            var productsWithCategory = _context.Produs.Where(p => p.CategorieProdus.Select(c => c.IdCategorie).FirstOrDefault() == idCategorie).ToList();

            if (productsWithCategory.Any())
                return isDeleted;
            else
            {
                var categorieToDelete = _context.Categorie.Where(c => c.IdCategorie == idCategorie).FirstOrDefault();
                _context.Categorie.Remove(categorieToDelete);
                _context.SaveChanges();
                isDeleted = true;
            }
            return isDeleted;

        }

        public bool ActualizeazaCategorie(Categorie categorie)
        {
            var esteActualizata = false;
            var categorieDeActualizat = _context.Categorie.Where(c => c.IdCategorie == categorie.IdCategorie).FirstOrDefault();
            categorieDeActualizat.NumeCategorie = categorie.NumeCategorie;
            _context.SaveChanges();
            esteActualizata = true;

            return esteActualizata;
        }

        public bool StergeProducator(int idProducator)
        {
            var isDeleted = false;
            var productsWithProducator = _context.Produs.Where(p => p.Producator.IdProducator == idProducator).ToList();

            if (productsWithProducator.Any())
                return isDeleted;
            else
            {
                var producatorToDelete = _context.Producator.Where(c => c.IdProducator == idProducator).FirstOrDefault();
                _context.Producator.Remove(producatorToDelete);
                _context.SaveChanges();
                isDeleted = true;
            }
            return isDeleted;
        }

        public Producator GetProducatorById(int idProducator)
        {
            return _context.Producator.FirstOrDefault(p => p.IdProducator == idProducator);
        }

        public bool ActualizeazaProducator(Producator producator)
        {
            var esteActualizat = false;
            if (producator != null)
            {
                var producatorDeActualizat = _context.Producator.FirstOrDefault(p => p.IdProducator == producator.IdProducator);
                producatorDeActualizat.Nume = producator.Nume;

                _context.SaveChanges();
                esteActualizat = true;
            }
            return esteActualizat;
        }

        public ComenziPlasateDataModel GetProduseComandate()
        {
            var comenziPlasateDataModel = new ComenziPlasateDataModel();

            comenziPlasateDataModel.ListaComenzi = _context.Comanda.ToList();
            comenziPlasateDataModel.ListaProduseComandate = _context.ComandaProdus.ToList();

            return comenziPlasateDataModel;
        }
    }
}
