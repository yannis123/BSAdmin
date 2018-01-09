using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IService;

using Domain.Model;
using System.Data;
using DapperExtensions;
namespace Domain.Service.VIPRecharge
{
    public class VIPRehargeService : IVIPRechargeService
    {

        private IDbConnection connection;
        public VIPRehargeService(IDBConnectionManager connManager)
        {
            connection = connManager.GetDefaultConn();
        }
        public void AddRechargeDtl(List<CCJLMX> rechargedDetail)
        {
            connection.Insert(rechargedDetail);
        }

        public void AddRecharges(List<CCJL> rechargeLst)
        {
            connection.Insert(rechargeLst);
        }

        public List<CCDA> GetArchives()
        {
            try
            {
                return connection.GetList<CCDA>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
