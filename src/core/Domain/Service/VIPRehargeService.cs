using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IService;

using Domain.Model;
using System.Data;
using DapperExtensions;
using Dapper;
namespace Domain.Service.VIPRecharge
{
    public class VIPRehargeService : IVIPRechargeService
    {

        private IDbConnection connection;
        public VIPRehargeService(IDBConnectionManager connManager)
        {
            connection = connManager.GetDefaultConn();
        }
        public void AddRechargeDtl(MR_CCJLMX rechargedDetail)
        {
            connection.Insert<MR_CCJLMX>(rechargedDetail);
        }

        public void AddRecharges(MR_CCJL recharge)
        {
            connection.Insert<MR_CCJL>(recharge);
        }
        /// <summary>
        /// 会员充值
        /// </summary>
        /// <param name="khdm">客户代码</param>
        /// <param name="czdm">充值代码</param>
        /// <param name="dydm">店员代码</param>
        /// <param name="sddm">店铺代码</param>
        /// <returns></returns>
        public bool AddRecharge(string vipdm, string czdm, string dydm, string sddm)
        {
            MR_CCDA ccda = GetArchive(czdm);

            IDbTransaction transaction = connection.BeginTransaction();
            try
            {
              
                int djbh = connection.Execute("insert into mr_ccjl (bz,dydm,rq,sddm) values (@bz,@dydm,@rq,@sddm);SELECT @@identity;",new
                {
                    bz = string.Empty,
                    dydm = dydm,
                    rq = DateTime.Now,
                    sddm = sddm
                }, transaction).FirstOrDefault();

                string number = "VC" + djbh.ToString().PadLeft(10, '0');

                connection.Insert<MR_CCJLMX>(new MR_CCJLMX()
                {
                    CZDM = ccda.CZDM,
                    CZJE = ccda.KCJE,
                    CZJF = ccda.CZJF,
                    VIPDM = vipdm,
                    ZZJE = ccda.ZZJE,
                    DJBH = djbh.ToString(),
                    ZY = ""
                }, transaction);
             
                connection.Execute("update mr_ccjl set DJBH_BAK=@DJBH_BAK where DJBH=@DJBH", new { DJBH_BAK = number, DJBH = djbh },transaction);

                connection.Execute("update MR_CCJLMX set DJBH_BAK=@DJBH_BAK where DJBH=@DJBH", new { DJBH_BAK = number, DJBH = djbh },transaction);
             
                transaction.Commit();
              
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }

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

        public MR_CCDA GetArchive(string czdm)
        {
            return connection.QuerySingle<MR_CCDA>("select * from mr_ccda where czdm=@czdm", new { czdm = czdm });
        }

    }
}
