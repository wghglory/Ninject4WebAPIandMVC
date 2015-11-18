using System;
using System.Collections.Generic;
using Ninject;

namespace Ninject_MVC_WebApi.Infrastruture
{
    public class NinjectDependencyResolverForMvc : System.Web.Mvc.IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolverForMvc(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }
            this.kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}