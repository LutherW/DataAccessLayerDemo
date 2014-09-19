using DataAccessLayerDemo.Infrastructure.UnitOfWork;
using DataAccessLayerDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.NHibernate.Repositories
{
    public class BookRepository : Repository<Book, Guid>, IBookRepository
    {
        public BookRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }
    }
}
