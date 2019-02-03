using System.Web.Mvc;
using MalweeCodeChallenge.Controllers;
using MalweeCodeChallenge.Core.Contracts.Interfaces;
using MalweeCodeChallenge.Core.Infra.EntityFramework;
using MalweeCodeChallenge.Core.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace MalweeCodeChallenge.App_Start
{
    public class BaseConfig
    {
        public static readonly Container Container = new Container();
        public static void ConfigureDependencies()
        {
            // Context
            var context = new MalweeContext();
            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            Container.Register<MalweeContext>(Lifestyle.Scoped);
            Container.Register<IRepositoryEscope, MalweeEscope>(Lifestyle.Scoped);
            Container.Register<IClientService, ClientService>(Lifestyle.Scoped);
            Container.Register<ISupplierService,SupplierService>(Lifestyle.Scoped);
            Container.Register<IServiceProvidedService>(()=> new ServiceProvidedService(context,new MalweeEscope(context)));

            Container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Container));
        }
    }
}