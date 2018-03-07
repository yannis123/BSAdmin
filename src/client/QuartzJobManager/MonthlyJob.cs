using Domain.IService;
using Domain.Service;
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
        private IScheduleJobsService _service;
        private IServiceconfiguration _config;

        public MonthlyJob(IScheduleJobsService service, IServiceconfiguration config)
        {
            service = _service;
            config = _config;
        }
        void IJob.Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("MonthlyJob测试");
        }
    }
}
