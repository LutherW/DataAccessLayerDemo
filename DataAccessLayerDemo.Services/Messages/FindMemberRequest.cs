﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.Services.Messages
{
    public class FindMemberRequest
    {
        public string MemberId { get; set; }
        public bool All { get; set; }
    }
}
