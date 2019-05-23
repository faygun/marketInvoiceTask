using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoanApi.Dto;

namespace LoanApi.Services
{
    public class LoanService : ILoanService
    {
        public LoanSummaryDto GetLoanSummary(double amount, double apr, int period = 52)
        {
            LoanSummaryDto result = new LoanSummaryDto();

            double interest = apr;
            double rateOfInterest = interest / (period * 100);
            double loanAmount = amount;
            double weeklyRePaid = Math.Round(loanAmount * (rateOfInterest * Math.Pow((1 + rateOfInterest), period)) /
                                        (Math.Pow((1 + rateOfInterest), period) - 1));

            double totalRepaid = weeklyRePaid * period;
            double totalInterest = totalRepaid - loanAmount;

            result = new LoanSummaryDto
            {
                TotalInterest = totalInterest,
                TotalRepaid = totalRepaid,
                WeeklyPayment = weeklyRePaid
            };

        
            return result;
        }
        private InstallmentDto calculateBalanceAmount(double installment, double amountDue, double interestRate, int period, int installmentNumber)
        {
            var interest = amountDue * (interestRate / (period * 100));
            var principal = installment - interest;

            return new InstallmentDto
            {
                AmountDue = amountDue,
                InstallmentNumber = installmentNumber,
                Interest = (int)Math.Round(interest),
                Principal = (int)principal
            };
        }
        public ScheduleDto GetRepaymentSchedule(double amount, double apr, int period = 52)
        {
            var result = new ScheduleDto();
            var loanSummary = GetLoanSummary(amount, apr, period);
            var amountDue = amount;
            var installmentAmount = loanSummary.WeeklyPayment;
            result.Installments = new List<InstallmentDto>();
            for (int week = 1; week <= period; week++)
            {
                InstallmentDto installment = calculateBalanceAmount(installmentAmount, amountDue, apr, period, week);
                result.Installments.Add(installment);
                amountDue -= installment.Principal;
            }

            return result;
        }
    }
}