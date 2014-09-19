using DataAccessLayerDemo.Infrastructure.UnitOfWork;
using DataAccessLayerDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.NHibernate.Repositories
{
    public class MemberRepository : Repository<Member, Guid>, IMemberRepository
    {
        public MemberRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }
    } 
}
