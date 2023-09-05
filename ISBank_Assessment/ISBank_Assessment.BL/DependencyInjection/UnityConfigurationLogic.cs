using AutoMapper;
using ISBank_Assessment.DL;
using System.Web;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace ISBank_Assessment.BL
{
    public class UnityConfigurationLogic
    {
        public IUnityContainer GetUnityContainer()
        {

            var container = new UnityContainer();

            #region User

            container.RegisterType<IUserLogic, UserLogic>();

            #endregion User

            #region Status
            container.RegisterType<IStatus, StatusLogic>();
            #endregion

            #region Person
            container.RegisterType<IPersonLogic, PersonLogic>();
            #endregion

            #region Account
            container.RegisterType<IAccountLogic, AccountLogic>();
            #endregion

            #region Transactions
            container.RegisterType<ITransactionLogic, TransactionLogic>();
            #endregion

            #region Infrastructure
            //container.RegisterType<IDataBaseManager, DataBaseManager>(new HierarchicalLifetimeManager());
            //container.RegisterType<IDbContextFactory, DbContextFactory>(new HierarchicalLifetimeManager(),
            //new InjectionConstructor(HttpContext.Current, new DataBaseManager()));
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager(),
            new InjectionConstructor(new DbContextFactory(null)));
            container.RegisterInstance<IMapper>(MappingConfiguration.RegisterMappings());
            #endregion

            return container;
        }
    }
}
