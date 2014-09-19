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
    public class BookTitleQueryTranslator : QueryTranslator
    {
        public ObjectQuery<BookTitle> Translate(Query query)
        {
            ObjectQuery<BookTitle> bookTitleQuery;

            if (query.IsNamedQuery())
            {
                bookTitleQuery = FindEFQueryFor(query);
            }
            else
            {
                StringBuilder queryBuilder = new StringBuilder();
                IList<ObjectParameter> paraColl = new List<ObjectParameter>();
                CreateQueryAndObjectParameters(query, queryBuilder, paraColl);

                bookTitleQuery = DataContextFactory.GetCurrentDataContext().BookTitles
                  .Where(queryBuilder.ToString(), paraColl.ToArray())
                  .OrderBy(String.Format("it.{0} {1}", query.OrderByProperty.PropertyName, query.OrderByProperty.Desc ? "desc" : "asc"));

            }

            return bookTitleQuery;
        }

        private ObjectQuery<BookTitle> FindEFQueryFor(Query query)
        {
            // No complex queries have been defined in this sample.
            throw new NotImplementedException();
        }
    }
}
