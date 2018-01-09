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
        void AddRechargeDtl(MR_CCJLMX rechargedDetail);
        List<MR_CCDA> GetArchives();
    }
}
