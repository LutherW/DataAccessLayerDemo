using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::NHibernate;
using System.Web;

namespace DataAccessLayerDemo.NHibernate.SessionStorage
{
    public class HttpSessionContainer : ISessionStorageContainer
    {
        private const string SESSION_KEY = "NHSession";

        public ISession GetCurrentSession()
        {
            ISession session = null;
            if (HttpContext.Current.Items.Contains(SESSION_KEY)) 
            {
                session = (ISession)HttpContext.Current.Items[SESSION_KEY];
            }

            return session;
        }

        public void Store(ISession session)
        {
            if (HttpContext.Current.Items.Contains(SESSION_KEY))
            {
                HttpContext.Current.Items[SESSION_KEY] = session;
            }
            else 
            {
                HttpContext.Current.Items.Add(SESSION_KEY, session);
            }
        }
    }
}
