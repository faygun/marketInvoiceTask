using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanApi.Dto;
using LoanApi.Services;

namespace LoanApi.Controllers
{
    public class LoanController : ApiController
    {
        const string apiPrefix = "api/v1/loan";
        private readonly ILoanService payment;
        public LoanController()
        {

        }
        public LoanController(LoanService _payment)
        {
            payment = _payment;
        }
        // GET api/<controller>
        [HttpGet]
        [Route(apiPrefix + "/loansummary")]
        public LoanSummaryDto GetLoanSummary(double amount, int apr, int period = 52)
        {
            if (amount <= 0 || apr <= 0 || period <= 0)
                return new LoanSummaryDto();

            return payment.GetLoanSummary(amount, apr, period);
        }

        [HttpGet]
        [Route(apiPrefix + "/repaymentSchedule")]
        public ScheduleDto GetRepaymentSchedule(double amount, int apr, int period = 52)
        {
            if (amount <= 0 || apr <= 0 || period <= 0)
                return new ScheduleDto();

            return payment.GetRepaymentSchedule(amount, apr, period);
        }

    }
}