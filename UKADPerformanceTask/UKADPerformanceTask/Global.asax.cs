using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using System.Reflection;
using UKADPerformanceTask.Models;
using UKADPerformanceTask.App_Start;

namespace UKADPerformanceTask
{
    public class MvcApplication : NinjectHttpApplication
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                });
        }

        // <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            logger.Info("Application Start");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override void OnApplicationStopped()
        {
            base.OnApplicationStopped();
            logger.Info("Application stopped");
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }
    }
}
