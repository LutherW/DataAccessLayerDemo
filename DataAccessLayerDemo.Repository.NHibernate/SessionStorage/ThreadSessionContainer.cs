using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.NHibernate.SessionStorage
{
    public class ThreadSessionContainer : ISessionStorageContainer
    {
        private static readonly Hashtable _nhsessions = new Hashtable();

        public ISession GetCurrentSession()
        {
            ISession nhsession = null;
            if (_nhsessions.Contains(GetThreadName()))
            {
                nhsession = (ISession)_nhsessions[GetThreadName()];
            }

            return nhsession;
        }

        private static string GetThreadName() 
        {
            return Thread.CurrentThread.Name;
        }

        public void Store(ISession session)
        {
            if (_nhsessions.Contains(GetThreadName()))
            {
                _nhsessions[GetThreadName()] = session;
            }
            else 
            {
                _nhsessions.Add(GetThreadName(), session);
            }
        }
    }
}
