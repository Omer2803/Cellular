using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cellular.Common.CRM;
using SimpleInjector;

namespace Cellular.CRM.DAL
{
    public class IoCManager
    {
        private readonly Container container;

        public IoCManager()
        {
            container = new Container();

            container.Register<IClientsRepository, ClientsRepository>();
            container.Register<ILinesPackagesRepository, LinesPackagesRepository>();
            container.Register<ILoginDal, LoginDal>();

            container.Verify();
        }


        public T GetInstanceOf<T>() where T :class
        {
            return container.GetInstance<T>();
        }
    }
}
