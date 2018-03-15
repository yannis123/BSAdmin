using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
    public class Serviceconfiguration : IServiceconfiguration
    {
        private const string DEFAULTCONNECTIONSTRING = "default";
        private const string BSCONNECTIONSTRING = "bsconnection";
        private const string WX_APPID = "AppId";
        private const string WX_APPSECRET = "AppSecret";
        private const string WX_REDIRECTURL = "RedirectUrl";
        private const string WX_TEMPLATEMESSAGEID = "TemplateMessageId";

        private const string MONTHLY_JOB_TEMPLATE_MESSAGE_ID = "MonthlyJobTemplateMessageId";
        private const string DAILY_JOB_TEMPLATE_MESSAGE_ID = "DailyJobTemplateMessageId";

        public string DefaultConnection
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[DEFAULTCONNECTIONSTRING].ConnectionString ?? "";
            }

        }
        public string BSConnection
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[BSCONNECTIONSTRING].ConnectionString ?? "";
            }

        }



        public string Wx_AppId
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings[WX_APPID] ?? "";
            }
        }

        public string Wx_AppSecret
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings[WX_APPSECRET] ?? "";
            }
        }


        public string Wx_RedirectUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings[WX_REDIRECTURL] ?? "";
            }
        }

        public string WX_TemplateMessageId
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings[WX_TEMPLATEMESSAGEID] ?? "";
            }

        }

        public string WX_Monthly_TemplateId
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings[MONTHLY_JOB_TEMPLATE_MESSAGE_ID] ?? "";
            }
        }

        public string WX_Daily_TemplateId
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings[DAILY_JOB_TEMPLATE_MESSAGE_ID] ?? "";
            }
        }
    }
}
