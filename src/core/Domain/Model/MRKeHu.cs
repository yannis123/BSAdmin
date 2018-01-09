using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class MRKeHu
    {
        /// <summary>
        ///客户代码
        /// </summary>
        public string KHDM { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string KHMC { get; set; }
        /// <summary>
        /// 渠道代码
        /// </summary>
        public string QDDM { get; set; }
        /// <summary>
        /// 渠道名称
        /// </summary>
        public string QDMC { get; set; }
        /// <summary>
        /// 区域代码
        /// </summary>
        public string QYDM { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string QYMC { get; set; }
      
    }
}
