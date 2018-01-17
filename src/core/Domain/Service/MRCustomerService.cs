using Domain.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using System.Data;
using Dapper;
using DapperExtensions;

namespace Domain.Service
{
    public class MRCustomerService : IMRCustomerService
    {
        private IDbConnection connection;
        public MRCustomerService(IDBConnectionManager connManager)
        {
            connection = connManager.GetDefaultConn();
        }

        public List<MR_Customer> GetCustomerList(int pageIndex, int pageSize, out int total, string sj, string khdm)
        {
            string sql = @"SELECT * FROM 
                        (SELECT 
                        mr_v_customer.*
                        , ROW_NUMBER()
                         OVER (ORDER BY mr_v_customer.dm DESC) rownum FROM  [dbo].mr_v_customer 
                        WHERE CKDM=@CKDM {2} 
                         ) as b WHERE  b.rownum 
                        BETWEEN {0} AND {1}  ORDER BY b.rownum";

            string where = string.Empty;
            if (!string.IsNullOrEmpty(sj))
            {
                where += " and sj='" + sj + "'";
            }

            sql = string.Format(sql, (pageIndex - 1) * pageSize + 1, pageIndex * pageSize, where);

            var list = connection.Query<MR_Customer>(sql, new { CKDM = khdm });

            string countsql = "select count(*) from mr_v_customer where 1=1 and CKDM=@CKDM ";
            if (!string.IsNullOrEmpty(sj))
            {
                countsql += " and sj='" + sj + "'";
            }

            total = connection.Query<int>(countsql, new { CKDM = khdm }).Single();

            return list.ToList<MR_Customer>();
        }

        public bool AddCustomer(MR_Customer customer)
        {
            string oldDM = @"select top 1 dm from   [dbo].[MR_V_CUSTOMER] where dm like 'KD%' order by dm desc";
            string maxDm = connection.ExecuteScalar<string>(oldDM);
            maxDm = !string.IsNullOrEmpty(maxDm) ? maxDm.Substring(2, 6) : "000000";

            string sql = @"insert into [MR_V_CUSTOMER] (DM,GKMC,SEX,SR,QDDM,CKDM,SJ,XGRQ) values
	                    (@DM,@GKMC,@SEX,@SR,@QDDM,@CKDM,@SJ,@XGRQ)";

            return connection.Execute(sql, new
            {
                DM = "KD" + (int.Parse(maxDm) + 1).ToString().PadLeft(6, '0'),
                GKMC = customer.GKMC,
                SR = customer.SR,
                QDDM = customer.QDDM,
                CKDM = customer.KHDM,
                SJ = customer.SJ,
                SEX = customer.SEX,
                XGRQ = customer.XGRQ
            }) > 0;
        }

    }
}
