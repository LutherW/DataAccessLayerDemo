using DataAccessLayerDemo.NHibernate.SessionStorage;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.NHibernate
{
    public class SessionFactory
    {
        private static ISessionFactory _nhsessionFactory;

        public static ISession GetCurrentSession() 
        {
            ISessionStorageContainer sessionContainer = SessionStorageFactory.GetStorageContainer();
            ISession currentSession = sessionContainer.GetCurrentSession();
            if (currentSession == null)
            {
                currentSession = GetNewSession();
                sessionContainer.Store(currentSession);
            }

            return currentSession;
        }

        private static void Init() 
        {
            Configuration config = new Configuration();
            config.AddAssembly("DataAccessLayerDemo.Repository.NHibernate");

            log4net.Config.XmlConfigurator.Configure();

            config.Configure();

            _nhsessionFactory = config.BuildSessionFactory();
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_nhsessionFactory == null)
            {
                Init();
            }

            return _nhsessionFactory;
        }

        private static ISession GetNewSession() 
        {
            return GetSessionFactory().OpenSession();
        }
    }
}
