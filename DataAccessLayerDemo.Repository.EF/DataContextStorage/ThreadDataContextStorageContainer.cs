using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.EF.DataContextStorage
{
    public class ThreadDataContextStorageContainer : IDataContextStorageContainer
    {
        private static readonly Hashtable _dataContexts = new Hashtable();

        public LibraryDataContext GetDataContext()
        {
            LibraryDataContext dataContext = null;
            if (_dataContexts.Contains(GetThreadName()))
            {
                dataContext = (LibraryDataContext)_dataContexts[GetThreadName()];
            }

            return dataContext;
        }

        public void Store(LibraryDataContext dataContext)
        {
            if (_dataContexts.Contains(GetThreadName()))
            {
                _dataContexts[GetThreadName()] = dataContext;
            }
            else 
            {
                _dataContexts.Add(GetThreadName(), dataContext);
            }
        }

        private static string GetThreadName() 
        {
            return Thread.CurrentThread.Name;
        }
    }
}
