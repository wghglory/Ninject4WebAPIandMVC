using System.Web.Http;
using System.Web.Mvc;
using Ninject;
using Ninject_Model.Abstract;
using Ninject_Model.Concrete;

namespace Ninject_MVC_WebApi.Infrastruture
{
    public class NinjectRegister
    {
        private static readonly IKernel Kernel;
        static NinjectRegister()
        {
            Kernel = new StandardKernel();
            AddBindings();
        }

        public static void RegisterFovMvc()
        {
            DependencyResolver.SetResolver(new NinjectDependencyResolverForMvc(Kernel));
        }

        public static void RegisterFovWebApi(HttpConfiguration config)
        {
            config.DependencyResolver = new NinjectDependencyResolverForWebApi(Kernel);
        }

        private static void AddBindings()
        {
            Kernel.Bind<IProductRepository>().To<ProductRepository>();
        }
    }
}