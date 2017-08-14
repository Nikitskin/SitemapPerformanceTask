using System.Web.Mvc;
using UKADPerformanceTask.Models;
using System;
using System.Collections.Generic;
using Ninject;

namespace UKADPerformanceTask.App_Start

{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType); 
        }

        private void AddBindings()
        {
        }
    }
}