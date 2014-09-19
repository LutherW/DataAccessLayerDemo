using DataAccessLayerDemo.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public void RegisterNew(Infrastructure.IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            unitOfWorkRepository.PersistCreationOf(entity);
        }

        public void RegisterRemoved(Infrastructure.IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            unitOfWorkRepository.PersistDeletionOf(entity);
        }

        public void RegisterAmended(Infrastructure.IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            unitOfWorkRepository.PersistUpdateOf(entity);
        }

        public void Commit()
        {
            DataContextFactory.GetCurrentDataContext().SaveChanges();
        }
    }
}
