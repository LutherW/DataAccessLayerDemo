﻿using DataAccessLayerDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.EF
{
    public class LibraryDataContext : ObjectContext
    {
        private ObjectSet<Member> _members;
        private ObjectSet<Book> _books;
        private ObjectSet<BookTitle> _bookTitles;

        public LibraryDataContext()
            : base("name=LibraryEntities", "LibraryEntities")  
        {
            _members = CreateObjectSet<Member>();
            _books = CreateObjectSet<Book>();
            _bookTitles = CreateObjectSet<BookTitle>();
            base.ContextOptions.LazyLoadingEnabled = true;           
        }
      
        public ObjectSet<Member> Members
        {
            get { return _members; }
        }

        public ObjectSet<Book> Books
        {
            get { return _books; }
        }
        
        public ObjectSet<BookTitle> BookTitles
        {
            get { return _bookTitles; }
        }
    }
}
