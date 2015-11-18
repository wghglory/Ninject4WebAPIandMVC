using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;   //!!!!!!!!!!!!!!webapi
using Ninject;
using Ninject.Syntax;

namespace Ninject_MVC_WebApi.Infrastruture
{
    public class NinjectDependencyResolverForWebApi : NinjectDependencyScope, System.Web.Http.Dependencies.IDependencyResolver 
    {
        private IKernel kernel;

        public NinjectDependencyResolverForWebApi(IKernel kernel)
            : base(kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel);
        }
    }

    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            Contract.Assert(resolver != null);

            this.resolver = resolver;
        }

        public void Dispose()
        {
            resolver = null;
        }

        public object GetService(Type serviceType)
        {
            return resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return resolver.GetAll(serviceType);
        }
    }
}