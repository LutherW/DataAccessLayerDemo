using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayerDemo.EF.DataContextStorage
{
    public class HttpDataContextStorageContainer : IDataContextStorageContainer
    {
        private const string DATACONTEXT_KEY = "DataContext";

        public LibraryDataContext GetDataContext()
        {
            LibraryDataContext dataContext = null;
            if (HttpContext.Current.Items.Contains(DATACONTEXT_KEY))
            {
                dataContext = (LibraryDataContext)HttpContext.Current.Items[DATACONTEXT_KEY];
            }

            return dataContext;
        }

        public void Store(LibraryDataContext dataContext)
        {
            if (HttpContext.Current.Items.Contains(DATACONTEXT_KEY))
            {
                HttpContext.Current.Items[DATACONTEXT_KEY] = dataContext;
            }
            else 
            {
                HttpContext.Current.Items.Add(DATACONTEXT_KEY, dataContext);
            }
        }
    }
}
