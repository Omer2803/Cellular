using Cellular.Common.BI;
using Cellular.Common.CRM;
using Cellular.Common.Invoices;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
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
            Invoices.BL.IoCManager invoicesIoc = new Invoices.BL.IoCManager();

            Container container = new Container();

            container.Register<IBIStatistics>(() => biIoc.GetInstanceOf<IBIStatistics>());

            container.Register<IClientsManager>(() => crmIoc.GetInstanceOf<IClientsManager>());
            container.Register<ILinesManager>(() => crmIoc.GetInstanceOf<ILinesManager>());
            container.Register<Common.CRM.IAuthenticator>(() => crmIoc.GetInstanceOf<Common.CRM.IAuthenticator>());

            container.Register<IInvoicesProducer>(() => invoicesIoc.GetInstanceOf<IInvoicesProducer>());
            container.Register<Common.Invoices.IAuthenticator>(() => invoicesIoc.GetInstanceOf<Common.Invoices.IAuthenticator>());
            container.Register<IOptimalPackageCalculator>(() => invoicesIoc.GetInstanceOf<IOptimalPackageCalculator>());
            container.Register<ISimulator>(() => invoicesIoc.GetInstanceOf<ISimulator>());

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

           // GlobalConfiguration.Configuration.Formatters.Clear();
           // GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
