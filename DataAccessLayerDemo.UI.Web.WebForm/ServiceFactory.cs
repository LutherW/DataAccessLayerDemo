using DataAccessLayerDemo.EF;
using DataAccessLayerDemo.EF.Repositories;
using DataAccessLayerDemo.Infrastructure.UnitOfWork;
using DataAccessLayerDemo.Model;
using DataAccessLayerDemo.NHibernate;
using DataAccessLayerDemo.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DataAccessLayerDemo.UI.Web.WebForm
{
    public static class ServiceFactory
    {
        public static LibraryService CreateLibraryService()
        {
            IUnitOfWork uow;
            IBookRepository bookRespository;
            IBookTitleRepository bookTitleRepository;
            IMemberRepository memberRespository;

            string persistenceStrategy = ConfigurationManager.AppSettings["PersistenceStrategy"];

            if (persistenceStrategy == "EF")
            {
                uow = new EFUnitOfWork();
                bookRespository = new BookRepository(uow);
                bookTitleRepository = new BookTitleRepository(uow);
                memberRespository = new MemberRepository(uow);
            }
            else
            {
                uow = new NHUnitOfWork();
                bookRespository = new DataAccessLayerDemo.NHibernate.Repositories.BookRepository(uow);
                bookTitleRepository = new DataAccessLayerDemo.NHibernate.Repositories.BookTitleRepository(uow);
                memberRespository = new DataAccessLayerDemo.NHibernate.Repositories.MemberRepository(uow);
            }

            return new LibraryService(uow, bookTitleRepository, bookRespository, memberRespository);
        }
    }
}