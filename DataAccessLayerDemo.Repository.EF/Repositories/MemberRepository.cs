using DataAccessLayerDemo.EF.QueryTranslators;
using DataAccessLayerDemo.Infrastructure.QueryObject;
using DataAccessLayerDemo.Infrastructure.UnitOfWork;
using DataAccessLayerDemo.Model;
using System;
using System.Data.Objects;
using System.Linq;

namespace DataAccessLayerDemo.EF.Repositories
{
    public class MemberRepository : Repository<Member, Guid>, IMemberRepository
    {
        public MemberRepository(IUnitOfWork uow)
            : base(uow)
        { }

        public override Member FindBy(Guid Id)
        {
            return GetObjectSet().FirstOrDefault<Member>(m => m.Id == Id);
        }

        public override IQueryable<Member> GetObjectSet()
        {
            return DataContextFactory.GetCurrentDataContext().CreateObjectSet<Member>();
        }

        public override string GetEntitySetName()
        {
            return "Members";
        }

        public override ObjectQuery<Member> TranslateIntoObjectQueryFrom(Query query)
        {
            return new MemberQueryTranslator().Translate(query);
        }
    }
}
