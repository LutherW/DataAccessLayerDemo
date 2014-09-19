using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.Services.Messages
{
    public class AddBookTitleRequest
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
    }
}
