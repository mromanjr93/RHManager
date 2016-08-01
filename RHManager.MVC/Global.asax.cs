using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RHManager.MVC.AutoMapper;

namespace RHManager.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // Para facilitar o mapeamento de objetos de domínio e objetos de ViewModel. utilizei o Framework AutoMapper
            // Criei umá classe estática para registrar todos meus mapeamentos, assim desacoplando a aplicação e evitando instancias desnecessárias.
            AutoMapperConfig.RegisterMappings();
        }
    }
}
