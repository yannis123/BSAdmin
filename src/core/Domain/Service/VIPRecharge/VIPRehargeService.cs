using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IService;
using Domain.IService.VIPRecharge;
using Domain.Model;
using System.Data;
using DapperExtensions;
namespace Domain.Service.VIPRecharge
{
    public class VIPRehargeService : IVIPRechargeService, IRechargeArchivesService, IVIPRechargeDetailService
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
            return connection.GetList<CCDA>().ToList();
        }
    }
}
