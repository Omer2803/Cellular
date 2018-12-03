using Cellular.Common.Invoices;
using Cellular.Invoices.DAL.Invoices;
using Cellular.Invoices.DAL.OptimalPackage;
using Cellular.Invoices.DAL.Simulator;
using SimpleInjector;

namespace Cellular.Invoices.DAL
{
    public class IoCManager
    {
        private readonly Container container;

        public IoCManager()
        {
            container = new Container();

            container.Register<IInvoicesRepository, InvoicesRepository>();
            container.Register<IDALAuthenticator, DALAuthenticator>();
            container.Register<IPriceList, PriceList>();
            container.Register<IOptimalPackageRepository, OptimalPackageRepository>();
            container.Register<ISimulatorRepository, SimulatorRepository>();

            container.Verify();
        }


        public T GetInstanceOf<T>() where T : class
        {
            return container.GetInstance<T>();
        }
    }
}
