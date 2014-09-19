﻿using DataAccessLayerDemo.Infrastructure.QueryObject;
using DataAccessLayerDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.EF.QueryTranslators
{
    public class MemberQueryTranslator : QueryTranslator
    {
        public ObjectQuery<Member> Translate(Query query)
        {
            ObjectQuery<Member> memberQuery;

            if (query.IsNamedQuery())
            {
                memberQuery = FindEFQueryFor(query);
            }
            else
            {
                StringBuilder queryBuilder = new StringBuilder();
                IList<ObjectParameter> paraColl = new List<ObjectParameter>();
                CreateQueryAndObjectParameters(query, queryBuilder, paraColl);

                memberQuery = DataContextFactory.GetCurrentDataContext().Members
                  .Where(queryBuilder.ToString(), paraColl.ToArray())
                  .OrderBy(String.Format("it.{0} {1}", query.OrderByProperty.PropertyName, query.OrderByProperty.Desc ? "desc" : "asc"));
            }

            return memberQuery;
        }

        private ObjectQuery<Member> FindEFQueryFor(Query query)
        {
            // No complex queries have been defined in this sample.
            throw new NotImplementedException();
        }
    }
}
