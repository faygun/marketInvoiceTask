using LoanApi.Dto;

namespace LoanApi.Services
{
    public interface ILoanService
    {
        LoanSummaryDto GetLoanSummary(double amount, double apr, int period = 52);

        ScheduleDto GetRepaymentSchedule(double amount, double apr, int period = 52);
    }
}
