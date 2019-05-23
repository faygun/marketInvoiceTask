using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanApi.Dto
{
    public class InstallmentDto
    {
        public int InstallmentNumber { get; set; }
        public double AmountDue { get; set; }
        public int Principal { get; set; }
        public int Interest { get; set; }
    }
}