﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerDemo.Infrastructure;
using DataAccessLayerDemo.Infrastructure.UnitOfWork;
using System.Data.Objects;
using DataAccessLayerDemo.Infrastructure.QueryObject;

namespace DataAccessLayerDemo.EF.Repositories
{
    public abstract class Repository<T, EntityKey> : IUnitOfWorkRepository where T : IAggregateRoot
    {
        private IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(T entity)
        {
            _unitOfWork.RegisterNew(entity, this);
        }

        public void Remove(T entity)
        {
            _unitOfWork.RegisterRemoved(entity, this);
        }

        public void Save(T entity)
        {
            // Do nothing as EF tracks changes
        }

        public abstract IQueryable<T> GetObjectSet();

        public abstract string GetEntitySetName();

        public abstract T FindBy(EntityKey Id);

        public abstract ObjectQuery<T> TranslateIntoObjectQueryFrom(Query query);

        public IEnumerable<T> FindAll()
        {
            return GetObjectSet().ToList<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            return GetObjectSet().Skip(index).Take(count).ToList<T>();
        }

        public IEnumerable<T> FindBy(Query query)
        {
            ObjectQuery<T> efQuery = TranslateIntoObjectQueryFrom(query);

            return efQuery.ToList<T>();
        }

        public IEnumerable<T> FindBy(Query query, int index, int count)
        {
            ObjectQuery<T> efQuery = TranslateIntoObjectQueryFrom(query);

            return efQuery.Skip(index).Take(count).ToList<T>();
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            DataContextFactory.GetCurrentDataContext().AddObject(GetEntitySetName(), entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            //  EF会自动跟踪变化
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            DataContextFactory.GetCurrentDataContext().DeleteObject(entity);
        }
    }
}
