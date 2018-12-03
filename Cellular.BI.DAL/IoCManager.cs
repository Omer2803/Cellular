using Cellular.Common.BI;
using SimpleInjector;

namespace Cellular.BI.DAL
{
    public class IoCManager
    {
        private readonly Container container;

        public IoCManager()
        {
            container = new Container();

            container.Register<IBIRepository, BIRepository>();

            container.Verify();
        }


        public T GetInstanceOf<T>() where T : class
        {
            return container.GetInstance<T>();
        }
    }
}
