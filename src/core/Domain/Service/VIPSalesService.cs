using Domain.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.VIPSales;
using System.Data;
using DapperExtensions;
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
    }
}
