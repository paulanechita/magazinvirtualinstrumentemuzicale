using MVIM.DAL.Interfete;
using MVIM.DAL.Repository;
using MVIM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVIM.DAL;

namespace MVIM.Domain.Managers
{
    public class ProdusManager : IProdusManager
    {
        //private IProdusRepository _repository;

        //public ProdusManager(IProdusRepository produsRepository)
        //{
        //    _repository = produsRepository; 
        //}
        
        private ProdusRepository _repository = new ProdusRepository();

        public bool AdaugaProdus(string descriereProdus, decimal pretProdus, string numeProdus, byte[] poza, int idCategorie, int idProducator)
        {
            return _repository.AdaugaProdus(descriereProdus, pretProdus, numeProdus, poza, idCategorie, idProducator);
        }

        public byte[] ReturnPhotos(int id)
        {
            return _repository.ReturnPhotos(id);
        }

        public List<Categorie> GetCategorii()
        {
            return _repository.GetCategorii();
        }

        public List<Producator> GetProducatori()
        {
            return _repository.GetProducatori();
        }

        public Categorie GetCategorieById(int id)
        {
            return _repository.GetCategorieById(id);
        }

        public void AdaugaCategorieNoua(string numeCategorie)
        {
            _repository.AdaugaCategorieNoua(numeCategorie);
        }

        public void AdaugaProducatorNou(string numeProducator)
        {
            _repository.AdaugaProducatorNou(numeProducator);
        }

        public List<Produs> GetProduse()
        {
            return _repository.GetProduse();
        }

        public Produs GetProdus(int id)
        {
            return _repository.GetProdus(id);
        }

        public bool ActualizeazaProdus(Produs produsActualizat, int idProdus)
        {
            return _repository.ActualizeazaProdus(produsActualizat, idProdus);
        }

        public bool StergeProdus(int id)
        {
            return _repository.StergeProdus(id);
        }

        public bool StergeCategorie(int idCategorie)
        {
            return _repository.StergeCategorie(idCategorie);
        }

        public bool ActualizeazaCategorie(Categorie categorie)
        {
            return _repository.ActualizeazaCategorie(categorie);
        }

        public bool StergeProducator(int idProducator)
        {
            return _repository.StergeProducator(idProducator);
        }

        public Producator GetProducatorById(int idProducator)
        {
            return _repository.GetProducatorById(idProducator);
        }

        public bool ActualizeazaProducator(Producator producator)
        {
            return _repository.ActualizeazaProducator(producator);
        }
    }
}
