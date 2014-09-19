using DataAccessLayerDemo.EF.QueryTranslators;
using DataAccessLayerDemo.Infrastructure.QueryObject;
using DataAccessLayerDemo.Infrastructure.UnitOfWork;
using DataAccessLayerDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.EF.Repositories
{
    public class BookRepository : Repository<Book, Guid>, IBookRepository
    {
        public BookRepository(IUnitOfWork uow)
            : base(uow)
        { }

        public override Book FindBy(Guid Id)
        {
            return GetObjectSet().FirstOrDefault<Book>(b => b.Id == Id);
        }

        public override IQueryable<Book> GetObjectSet()
        {
            return DataContextFactory.GetCurrentDataContext().CreateObjectSet<Book>();
        }

        public override string GetEntitySetName()
        {
            return "Books";
        }

        public override ObjectQuery<Book> TranslateIntoObjectQueryFrom(Query query)
        {
            return new BookQueryTranslator().Translate(query);
        }
    }
}
