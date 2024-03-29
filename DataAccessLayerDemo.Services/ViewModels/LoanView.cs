﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.Services.ViewModels
{
    public class LoanView
    {
        public string BookTitle { get; set; }
        public string CopyId { get; set; }
        public string LoanId { get; set; }
        public string LoanDate { get; set; }
        public string ReturnDate { get; set; }
        public string DateForReturn { get; set; }
        public string MemberName { get; set; }
        public string MemberId { get; set; }
        public bool StillOutOnLoan { get; set; }
    }
}
