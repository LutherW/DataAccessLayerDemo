using DataAccessLayerDemo.Infrastructure.UnitOfWork;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork
    {
        public void RegisterNew(Infrastructure.IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void RegisterRemoved(Infrastructure.IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        public void RegisterAmended(Infrastructure.IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public void Commit()
        {
            using (ITransaction transaction = SessionFactory.GetCurrentSession().BeginTransaction()) 
            {
                try
                {
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
