
using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzJobManager
{
    public class DailyJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(QuartzJobManager.DailyJob));

         void IJob.Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("Daily测试");
        }
    }
}
