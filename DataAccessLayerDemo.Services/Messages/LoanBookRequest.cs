﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.Services.Messages
{
    public class LoanBookRequest
    {
        public string MemberId { get; set; }
        public string CopyId { get; set; }
    }
}
