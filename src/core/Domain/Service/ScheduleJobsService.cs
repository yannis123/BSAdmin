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

    public class ScheduleJobsService: IScheduleJobsService
    {
        private IDbConnection connection;
        public ScheduleJobsService(IDBConnectionManager connManager)
        {
            connection = connManager.GetDefaultConn();
        }

        public List<MR_Customer> GetCustomerList(DateTime currentTime)
        {
            string sql = @"SELECT * FROM [dbo].mr_v_customer";

            string where = string.Empty;
            //if (!string.IsNullOrEmpty(sj))
            //{
            //    where += " and sj='" + sj + "'";
            //}

            // sql = string.Format(sql, (pageIndex - 1) * pageSize + 1, pageIndex * pageSize, where);
            var khdm = "";
            var list = connection.Query<MR_Customer>(sql, new { CKDM = khdm });

            return list.ToList<MR_Customer>();
        }

    }
}
