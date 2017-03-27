using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Practices.Unity;
using MVCInventory.Business;
using Unity.Mvc5;

namespace MVCInventory.WebUI
{
    public static class UnityConfig
    {
        public static IUnityContainer Config()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<MapperProfile>();
              
            });
            var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
             container.RegisterType<IFacilityManager, FacilityManager>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));


            return container;
        }
    }
}