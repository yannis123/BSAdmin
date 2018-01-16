using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
namespace Domain.IService
{
    public interface IVIPRechargeService
    {
        void AddRecharges(MR_CCJL recharge);
        bool AddRecharge(string vipdm, string czdm, string dydm, string sddm);
        void AddRechargeDtl(MR_CCJLMX rechargedDetail);
        List<MR_CCDA> GetArchives();

        MR_CCDA GetArchive(string czdm);
        List<RechargeRecord> GetRechargeList(int pageIndex, int pageSize, out int total, string khdm, string sj);
    }
}
