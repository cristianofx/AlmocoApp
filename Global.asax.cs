using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AlmocoApp.Models;
using System.Data.Entity;

namespace AlmocoApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //inicializador dos bancos de dados
            Database.SetInitializer<DatabaseContext>(new InicializadorCategorias());
            Database.SetInitializer<DatabaseContext>(new InicializadorRestaurantes());
        }
    }
}
