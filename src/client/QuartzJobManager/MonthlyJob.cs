using Domain.IService;
using Domain.Service;
using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senparc.Weixin.MP.CommonAPIs;
using QuartzJobManager.Model;
using Domain;

namespace QuartzJobManager
{
    public class MonthlyJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(QuartzJobManager.MonthlyJob));


        private static IServiceconfiguration _config = new Serviceconfiguration();
        private static IDBConnectionManager _manager = new DBConnectionManager(_config);
        private IScheduleJobsService _service = new ScheduleJobsService(_manager);


        void IJob.Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("MonthlyJob测试");




            var accessToken = AccessTokenContainer.GetAccessToken(_config.Wx_AppId);
            var templateId = _config.WX_Monthly_TemplateId;

            var customerList = _service.GetCustomerListForMonthly();
            _logger.InfoFormat("=========customer  log===============");
            _logger.InfoFormat(string.Format("customer list count:{0}", customerList.Count()));

            int index = 0;
            customerList.ForEach(m =>
            {
                index++;
                _logger.InfoFormat(string.Format("serial number:{0} ", index));
                _logger.InfoFormat(string.Format("customer name:{0}", m.KHMC));
                var testData = new XFTemplateData()
                {
                    //BirthDay=new TemplateDataItem(m.SR, "#000000"),
                    //ShopName=new TemplateDataItem(m.KHMC, "#000000")
                    time = new TemplateDataItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "##000000"),
                    first = new TemplateDataItem("【In's品牌】尊敬的In's会员，您好~"),
                    remark = new TemplateDataItem(string.Format("温馨提醒：您在我专柜店铺开卡登记的生日{0}快要到来，本店特地为您\r\n准备了专属您的生日小礼物呦~，环境您本月到店领取，不胜荣幸", DateTime.Parse(m.SR).ToString("yyyy-MM-dd")))


                };

                var result = Senparc.Weixin.MP.AdvancedAPIs.TemplateApi.SendTemplateMessage(accessToken, m.WXOPENID, templateId, "#FF0000", "", testData);
            });


        }
    }
}
