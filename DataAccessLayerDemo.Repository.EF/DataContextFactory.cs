using DataAccessLayerDemo.EF.DataContextStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.EF
{
    public class DataContextFactory
    {
        public static LibraryDataContext GetCurrentDataContext() 
        {
            IDataContextStorageContainer storageContainer = DataContextStorageFactory.GetStorageContainer();
            LibraryDataContext dataContext = storageContainer.GetDataContext();
            if (dataContext == null)
            {
                dataContext = new LibraryDataContext();
                storageContainer.Store(dataContext);
            }

            return dataContext;
        }
    }
}
