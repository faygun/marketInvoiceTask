using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanApi.Dto
{
    public class ScheduleDto
    {
        public List<InstallmentDto> Installments { get; set; }
    }
}