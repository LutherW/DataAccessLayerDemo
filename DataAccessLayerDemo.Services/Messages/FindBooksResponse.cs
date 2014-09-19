using DataAccessLayerDemo.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.Services.Messages
{
    public class FindBooksResponse : ResponseBase
    {
        public IEnumerable<BookView> Books { get; set; } 
    }
}
