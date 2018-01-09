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
        void AddRecharges(List<MR_CCJL> rechargeLst);
        void AddRechargeDtl(List<MR_CCJLMX> rechargedDetailLst);
        List<MR_CCDA> GetArchives();
    }
}
