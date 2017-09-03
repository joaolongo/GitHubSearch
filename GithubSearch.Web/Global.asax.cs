using GithubSearch.Web.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

namespace GithubSearch.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MapperConfig.Config();
        }
    }
}
