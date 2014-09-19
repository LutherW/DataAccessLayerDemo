using DataAccessLayerDemo.Infrastructure.QueryObject;
using DataAccessLayerDemo.Infrastructure.UnitOfWork;
using DataAccessLayerDemo.Model;
using System;
using System.Data.Objects;
using System.Linq;

namespace DataAccessLayerDemo.EF.Repositories
{
    public class BookTitleRepository : Repository<BookTitle, string>, IBookTitleRepository
    {
        public BookTitleRepository(IUnitOfWork uow)
            : base(uow)
        { }

        public override BookTitle FindBy(string Id)
        {
            return GetObjectSet().FirstOrDefault<BookTitle>(b => b.ISBN == Id);
        }

        public override IQueryable<BookTitle> GetObjectSet()
        {
            return DataContextFactory.GetCurrentDataContext().CreateObjectSet<BookTitle>();
        }

        public override string GetEntitySetName()
        {
            return "BookTitles";
        }

        public override ObjectQuery<BookTitle> TranslateIntoObjectQueryFrom(Query query)
        {
            throw new NotImplementedException();
        }
    }
}
