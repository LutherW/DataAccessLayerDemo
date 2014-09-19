using DataAccessLayerDemo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.Model
{
    public class Book :IAggregateRoot
    {
        public Guid Id { get; set; }
        public virtual BookTitle Title { get; set; }
        public virtual Member OnLoanTo { get; set; }
    }
}
