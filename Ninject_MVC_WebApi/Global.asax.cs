using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Ninject_MVC_WebApi.Infrastruture;

namespace Ninject_MVC_WebApi
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            NinjectRegister.RegisterFovMvc(); //为ASP.NET MVC注册IOC容器
            NinjectRegister.RegisterFovWebApi(GlobalConfiguration.Configuration); //为WebApi注册IOC容器
        }
    }
}