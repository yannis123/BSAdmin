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
        public void AddRechargeDtl(List<MR_CCJLMX> rechargedDetail)
        {
            connection.Insert(rechargedDetail);
        }

        public void AddRecharges(List<MR_CCJL> rechargeLst)
        {
            connection.Insert(rechargeLst);
        }

        public List<MR_CCDA> GetArchives()
        {
            try
            {
                return connection.GetList<MR_CCDA>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
