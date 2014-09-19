using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository);

        void Commit();
    }
}
