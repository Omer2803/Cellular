using Cellular.Common.Invoices;
using Cellular.Invoices.BL.Invoices;
using Cellular.Invoices.BL.OptimalPackage;
using SimpleInjector;

namespace Cellular.Invoices.BL
{
    public class IoCManager
    {
        private readonly Container container;

        public IoCManager()
        {
            DAL.IoCManager dalIoc = new DAL.IoCManager();

            container = new Container();

            container.Register<IAuthenticator>(() => new Authenticator(dalIoc.GetInstanceOf<IDALAuthenticator>()));
            container.Register<IInvoicesProducer>(() =>
            new InvoicesProducer(dalIoc.GetInstanceOf<IInvoicesRepository>(),
            dalIoc.GetInstanceOf<IPriceList>()));
            container.Register<IOptimalPackageCalculator>(() =>
            new OptimalPackageCalculator(dalIoc.GetInstanceOf<IOptimalPackageRepository>(),
                dalIoc.GetInstanceOf<IPriceList>()));
            container.Register<ISimulator>(() => new Simulator.Simulator(dalIoc.GetInstanceOf<ISimulatorRepository>()));

            container.Verify();
        }


        public T GetInstanceOf<T>() where T : class
        {
            return container.GetInstance<T>();
        }
    }
}
