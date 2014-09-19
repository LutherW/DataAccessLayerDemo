using DataAccessLayerDemo.Infrastructure;
using DataAccessLayerDemo.Infrastructure.QueryObject;
using DataAccessLayerDemo.Infrastructure.UnitOfWork;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.NHibernate.Repositories
{
    public abstract class Repository<T,EntityKey> where T : IAggregateRoot
    {
        private IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(T entity) 
        {
            _unitOfWork.RegisterNew(entity, null);
        }

        public void Remove(T entity)
        {
            _unitOfWork.RegisterRemoved(entity, null);
        }

        public void Save(T entity)
        {
            _unitOfWork.RegisterAmended(entity, null);
        }

        public T FindBy(EntityKey Id)
        {
            return SessionFactory.GetCurrentSession().Get<T>(Id);
        }

        public IEnumerable<T> FindAll()
        {
            ICriteria CriteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            return (List<T>)CriteriaQuery.List<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            ICriteria CriteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            return (List<T>)CriteriaQuery.SetFetchSize(count).SetFirstResult(index).List<T>();
        }

        public IEnumerable<T> FindBy(Query query)
        {
            ICriteria nhQuery = query.Translate<T>();

            return nhQuery.List<T>();
        }

        public IEnumerable<T> FindBy(Query query, int index, int count)
        {
            ICriteria nhQuery = query.Translate<T>();

            return nhQuery.SetFetchSize(count).SetFirstResult(index).List<T>();
        } 
    }
}
