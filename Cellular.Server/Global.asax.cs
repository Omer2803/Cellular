using Cellular.Common.BI;
using Cellular.Common.CRM;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Cellular.Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            CRM.BL.IoCManager crmIoc = new CRM.BL.IoCManager();
            BI.BL.IoCManager biIoc = new BI.BL.IoCManager();

            Container container = new Container();

            container.Register<IBIStatistics>(() => biIoc.GetInstanceOf<IBIStatistics>());

            container.Register<IClientsManager>(() => crmIoc.GetInstanceOf<IClientsManager>());
            container.Register<ILinesManager>(() => crmIoc.GetInstanceOf<ILinesManager>());
            container.Register<IAuthenticator>(() => crmIoc.GetInstanceOf<IAuthenticator>());

            container.Verify();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
