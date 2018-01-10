﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class MR_Customer
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string DM { get; set; }
        /// <summary>
        /// 顾客名称
        /// </summary>
        public string GKMC { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string SEX { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string SR { get; set; }
        /// <summary>
        /// 区域代码
        /// </summary>
        public string QYDM { get; set; }
        /// <summary>
        /// 渠道代码
        /// </summary>
        public string QDDM { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal XFJE { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string SJ { get; set; }
        /// <summary>
        /// 当前积分
        /// </summary>
        public int DQJF { get; set; }

        /// <summary>
        /// 渠道
        /// </summary>
        public MR_QuDao QUDAO { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public MR_QuYu QUYU { get; set; }

    }

    public class MR_QuYu
    {
        public string QYDM { get; set; }
        public string QYMC { get; set; }
    }
    public class MR_QuDao
    {
        public string QDDM { get; set; }
        public string QDMC { get; set; }
    }
}