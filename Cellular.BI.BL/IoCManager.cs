using Cellular.Common.BI;
using SimpleInjector;

namespace Cellular.BI.BL
{
    public class IoCManager
    {
        private readonly Container container;

        public IoCManager()
        {
            DAL.IoCManager dalIoc = new DAL.IoCManager();

            container = new Container();

            container.Register<IBIStatistics>(() => new BIStatistics(dalIoc.GetInstanceOf<IBIRepository>()));

            container.Verify();
        }


        public T GetInstanceOf<T>() where T : class
        {
            return container.GetInstance<T>();
        }
    }

}
