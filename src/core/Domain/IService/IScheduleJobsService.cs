using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
    public interface IScheduleJobsService
    {
        List<MR_Customer> GetCustomerListForMonthly();
        List<MR_Customer> GetCustomerListForDaily();
    }
}
