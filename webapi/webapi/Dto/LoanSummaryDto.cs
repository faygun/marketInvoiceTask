using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanApi.Dto
{
    public class LoanSummaryDto
    {
        public double WeeklyPayment { get; set; }
        public double TotalRepaid { get; set; }
        public double TotalInterest { get; set; }
    }
}