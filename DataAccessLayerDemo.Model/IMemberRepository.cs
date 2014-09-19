using DataAccessLayerDemo.Infrastructure.QueryObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.Model
{
    public interface IMemberRepository
    {
        void Add(Member member);
        void Remove(Member member);
        void Save(Member member);

        Member FindBy(Guid Id);

        IEnumerable<Member> FindAll();
        IEnumerable<Member> FindAll(int index, int count);

        IEnumerable<Member> FindBy(Query query);
        IEnumerable<Member> FindBy(Query query, int index, int count);   
    }
}
