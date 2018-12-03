using Cellular.Common.CRM;
using SimpleInjector;

namespace Cellular.CRM.BL
{
    public class IoCManager
    {
        private readonly Container container;

        public IoCManager()
        {
            DAL.IoCManager dalIoc = new DAL.IoCManager();

            container = new Container();

            container.Register<IClientsManager>(() => new ClientsManager(dalIoc.GetInstanceOf<IClientsRepository>()));
            container.Register<ILinesManager>(() => new LinesManager(dalIoc.GetInstanceOf<ILinesPackagesRepository>()));
            container.Register<IAuthenticator, Authenticator>();
            container.Register<>

            container.Verify();
        }


        public T GetInstanceOf<T>() where T : class
        {
            return container.GetInstance<T>();
        }
    }
}
