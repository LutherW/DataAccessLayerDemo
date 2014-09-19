using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayerDemo.EF.DataContextStorage
{
    public static class DataContextStorageFactory
    {
        private static IDataContextStorageContainer _dataContectStorageContainer;

        public static IDataContextStorageContainer GetStorageContainer()
        {
            if (_dataContectStorageContainer == null)
            {
                if (HttpContext.Current == null)
                {
                    _dataContectStorageContainer = new ThreadDataContextStorageContainer();
                }
                else
                {
                    _dataContectStorageContainer = new HttpDataContextStorageContainer();
                }
            }

            return _dataContectStorageContainer;
        }
    }
}
