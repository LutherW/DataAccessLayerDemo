﻿using DataAccessLayerDemo.Model;
using DataAccessLayerDemo.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.Services.Mappers
{
    public static class LoanExtensionMethods
    {
        public static LoanView ConvertToLoanView(this Loan loan)
        {
            return new LoanView
            {
                BookTitle = loan.Book.Title.Title,
                CopyId = loan.Book.Id.ToString(),
                LoanId = loan.Id.ToString(),
                MemberId = loan.Member.Id.ToString(),
                MemberName = loan.Member.FirstName + ' ' + loan.Member.LastName,
                LoanDate = loan.LoanDate.ToString(),
                ReturnDate = loan.ReturnDate.ToString(),
                DateForReturn = loan.DateForReturn.ToString(),
                StillOutOnLoan = loan.HasNotBeenReturned()
            };
        }

        public static IList<LoanView> ConvertToLoanViews(this IEnumerable<Loan> loans)
        {
            IList<LoanView> loanViews = new List<LoanView>();
            foreach (Loan loan in loans)
            {
                loanViews.Add(loan.ConvertToLoanView());
            }

            return loanViews;
        }
    }
}
