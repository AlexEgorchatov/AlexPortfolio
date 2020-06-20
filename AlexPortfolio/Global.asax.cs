using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AlexPortfolio
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_EndRequest()
        {
            // Any AJAX request that ends in a redirect should get mapped to an unauthorized request
            // since it should only happen when the request is not authorized and gets automatically
            // redirected to the login page.
            var context = new HttpContextWrapper(Context);
            if (context.Response.StatusCode == 302 && context.Request.IsAjaxRequest())
            {
                context.Response.Clear();
                Context.Response.StatusCode = 401;
            }
        }
    }
}
