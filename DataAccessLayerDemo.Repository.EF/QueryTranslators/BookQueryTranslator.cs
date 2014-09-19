using DataAccessLayerDemo.Infrastructure.QueryObject;
using DataAccessLayerDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.EF.QueryTranslators
{
    public class BookQueryTranslator : QueryTranslator
    {
        public ObjectQuery<Book> Translate(Query query)
        {
            ObjectQuery<Book> bookQuery;

            if (query.IsNamedQuery())
            {
                bookQuery = FindEFQueryFor(query);
            }
            else
            {
                StringBuilder queryBuilder = new StringBuilder();
                IList<ObjectParameter> paraColl = new List<ObjectParameter>();
                CreateQueryAndObjectParameters(query, queryBuilder, paraColl);

                bookQuery = DataContextFactory.GetCurrentDataContext().Books.Include("Title")
                  .Where(queryBuilder.ToString(), paraColl.ToArray())
                  .OrderBy(String.Format("it.{0} {1}", query.OrderByProperty.PropertyName, query.OrderByProperty.Desc ? "desc" : "asc"));
            }

            return bookQuery;
        }

        private ObjectQuery<Book> FindEFQueryFor(Query query)
        {
            // No complex queries have been defined in this sample.
            throw new NotImplementedException();
        }
    }
}
