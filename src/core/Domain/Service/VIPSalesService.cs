using Domain.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.VIPSales;
using System.Data;
using DapperExtensions;
using Domain.Model;
using Dapper;
using System.Data.SqlClient;

namespace Domain.Service
{
    public class VIPSalesService : IVIPSalesService
    {

        private IDbConnection connection;
        public VIPSalesService(IDBConnectionManager conneManage)
        {
            connection = conneManage.GetDefaultConn();
        }

        public void AddSales(MR_XSJL sale)
        {
            connection.Insert<MR_XSJL>(sale);
        }

        public void AddSalesDel(MR_XSJLMX saleDel)
        {
            connection.Insert<MR_XSJLMX>(saleDel);
        }

        public List<MR_Customer> GetCustomer(string phone)
        {
            var customers = connection.Query<MR_Customer>(" select * from MR_V_CUSTOMER where sj=@sj", new { sj = phone });
            if (!customers.Any())
                return new List<MR_Customer>();
            return customers.ToList();
        }

        public List<MR_DianYuan> GetDY(string param, string khdm)
        {
            var sql = @"select * from [dbo].[MR_DIANYUAN] where KHDM='" + khdm + "' DYDM like '%" + param + "%' or DYMC like '%" + param + "%'";
            var dys = connection.Query<MR_DianYuan>(sql);

            if (!dys.Any())
                return new List<MR_DianYuan>();
            return dys.ToList();
        }

        public List<MR_SHANGPIN> GetSP(string SPDM)
        {
            var sps = connection.Query<MR_SHANGPIN>(
                @"select sp.SPDM,sp.SPMC,sp.BZSJ,sp1.GGDM as GG1DM,gg1.GGMC as GG1MC,sp2.GGDM as GG2DM ,gg2.GGMC as GG2MC
                    from[dbo].[MR_SHANGPIN] sp
                  left join
                    [dbo].[MR_SPGG1] sp1 on sp.SPDM = sp1.SPDM
                  left join
                    [dbo].[MR_GUIGE1]gg1 on sp1.GGDM = gg1.GGDM
                  left join
                    [dbo].[MR_SPGG2] sp2 on sp.SPDM = sp2.SPDM
                  left join
                    [dbo].[MR_GUIGE2] gg2 on sp2.GGDM = gg2.GGDM
                    where sp.spdm = @spdm", new { spdm = SPDM });
            if (!sps.Any())
                return new List<MR_SHANGPIN>();
            return sps.ToList();

        }
    }
}
