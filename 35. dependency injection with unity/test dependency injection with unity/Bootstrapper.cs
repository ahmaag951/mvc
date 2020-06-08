using System.Web.Mvc;
//using DataAccess.Data;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
//using Service;
//using DataAccess.Common;

namespace test_dependency_injection_with_unity
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();            
            //container.RegisterType<IGreetingService, GreetingService>();
            container.RegisterType<IGreetingService, GreetingService2>();
            //container.RegisterType<IEmployeeService, EmployeeService>();
            //container.RegisterType<IUnitOfWork, UnitOfWork>();
            //container.RegisterType<IDbContextManager, DbContextManager<CompanyEntities>>();
            //container.RegisterType<IDbContextFactory<CompanyEntities>, DbContextFactory>();

            //container.RegisterType<IEnumerable<IDbContextManager>().;

            //container.RegisterType<DbContext, SecurityDbContext>().;

            //container.RegisterType<IEnumerable<IDbContextManager>, DbContextManager<CompanyEntities>>();

            //x.For<IEnumerable<IDbContextManager>>()
            //                  .Use(c => c.GetAllInstances<IDbContextManager>());


            
            return container;
        }
    }
}