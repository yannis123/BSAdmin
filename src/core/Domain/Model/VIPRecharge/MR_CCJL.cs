using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class MR_CCJL
    {
        public DateTime RQ { get; set; }
        public string SDDM { get; set; }
        public string DYDM { get; set; }
        public string BZ { get; set; }
    }

    public class RechargeRecord
    {
        /// <summary>
        /// 登记编号
        /// </summary>
        public string DJBH { get; set; }
        /// <summary>
        /// 登记编号代码
        /// </summary>
        public string DJBH_BAK { get; set; }
        /// <summary>
        /// 充值日期
        /// </summary>
        public string RQ { get; set; }
        /// <summary>
        /// 店铺代码
        /// </summary>
        public string SDDM { get; set; }
        /// <summary>
        /// 店员代码
        /// </summary>
        public string DYDM { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string BZ { get; set; }
        /// <summary>
        /// 顾客代码
        /// </summary>
        public string VIPDM { get; set; }
        /// <summary>
        /// 充值代码
        /// </summary>
        public string CZDM { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal CZJE { get; set; }
        /// <summary>
        /// 赠送金额
        /// </summary>
        public decimal ZSJE { get; set; }
        /// <summary>
        /// 增值金额
        /// </summary>
        public decimal ZZJE { get; set; }
        /// <summary>
        /// 充值积分
        /// </summary>
        public double CZJF { get; set; }
        /// <summary>
        /// 店员名称
        /// </summary>
        public string DYMC { get; set; }
        /// <summary>
        /// 顾客名称
        /// </summary>
        public string GKMC { get; set; }
        /// <summary>
        /// 顾客手机号码
        /// </summary>
        public string SJ { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string KHMC { get; set; }
    }
}
