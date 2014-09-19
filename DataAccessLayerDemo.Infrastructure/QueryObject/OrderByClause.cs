using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayerDemo.Infrastructure.QueryObject
{
    public class OrderByClause
    {
        public string PropertyName { get; set; }
        public bool Desc { get; set; }
    }
}
