﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.Services.ViewModels
{
    public class BookView
    {
        public string Id { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string OnLoanTo { get; set; }    
    }
}
