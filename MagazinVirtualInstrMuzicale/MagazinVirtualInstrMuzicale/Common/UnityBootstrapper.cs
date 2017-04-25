using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using MVIM.DAL;
using MVIM.DAL.Interfete;
using MVIM.DAL.Repository;
using MVIM.Domain.Interfaces;
using MVIM.Domain.Managers;
using System.Web.Mvc;

namespace MagazinVirtualInstrMuzicale.Common
{
    public class UnityBootstrapper
    {
        public static void Initialize()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }        

        private static UnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // Silhouette Entities Context
            container.RegisterType<MVIMEntities>();

            // Repositories
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IProdusRepository, ProdusRepository>();

            // Managers
            container.RegisterType<IUserManager, UserManager>();
            container.RegisterType<IProdusManager, ProdusManager>();

            return container;
        }
    }
}