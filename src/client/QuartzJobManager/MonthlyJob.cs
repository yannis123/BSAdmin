using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzJobManager
{
    public class MonthlyJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(QuartzJobManager.MonthlyJob));

        void IJob.Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("MonthlyJob测试");
        }
    }
}
