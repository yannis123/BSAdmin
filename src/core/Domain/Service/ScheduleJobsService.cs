using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Domain.Model;
using Domain.IService;

namespace Domain.Service
{

    public class ScheduleJobsService : IScheduleJobsService
    {
        private IDbConnection connection;
        public ScheduleJobsService(IDBConnectionManager connManager)
        {
            connection = connManager.GetDefaultConn();
        }

        public List<MR_Customer> GetCustomerListForMonthly()
        {

            //string sql = @"select  kh.KHMC,cu.SR from [dbo].[MR_V_CUSTOMER] cu left join [dbo].[MR_KEHU] kh on cu.CKDM=kh.KHDM  where cu.sr is not null and  month(cu.sr)=MONTH(getdate()) and (cu.WXOPENID is not null or cu.WXOPENID !='')";
            string sql = "SELECT * from [dbo].[MR_V_CUSTOMER] where SJ='18521590012'";
            var list = connection.Query<MR_Customer>(sql);



            return list.ToList<MR_Customer>();
        }

        public List<MR_Customer> GetCustomerListForDaily()
        {
            var now = DateTime.Now;
            var endDate = now.AddDays(5);
            var month = endDate.Month;
            var day = endDate.Day;

            string sql = string.Format("select kh.KHMC,cu.SR  from [dbo].[MR_V_CUSTOMER] cu left join [dbo].[MR_KEHU] kh on cu.CKDM=kh.KHDM  where month(cu.sr)={0} and day(cu.sr)={1} and(cu.WXOPENID is not null or cu.WXOPENID !='')", month, day);

            var list = connection.Query<MR_Customer>(sql);

            return list.ToList<MR_Customer>();
        }

    }
}
