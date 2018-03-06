using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Model
{
    public class OrderInfo
    {
        public string gkdm { get; set; }
        public string dydm { get; set; }
        public double discountPoint { get; set; }
        public List<Products> products { get; set; }
        public string sddm { get; set; }
    }
    public class Products
    {
        public string spdm { get; set; }
        public decimal price { get; set; }
        public string gg1dm { get; set; }
        public string gg1mc { get; set; }
        public string gg2dm { get; set; }
        public string gg2mc { get; set; }
        public decimal bzsj { get; set; }
        public int count { get; set; }
    }

    public class MainOrder
    {
        public string DJBH { get; set; }
        public string RQ { get; set; }
        public string SDDM { get; set; }
        public string KHMC { get; set; }
        public string DYDM { get; set; }
        public string DYMC { get; set; }
        public string VIPDM { get; set; }
        public string GKMC { get; set; }
        public string SJ { get; set; }
        public string BZ { get; set; }
        public double ZK { get; set; }
        public decimal ZKJE { get; set; }
        public string ZJE { get; set; }
    }

    public class OrderResponse
    {
        public string Error { get; set; }
        public decimal DQJE { get; set; }
        public string GKMC { get; set; }
        public decimal BCXFJE { get; set; }
        public decimal XFJE { get; set; }
        public string SJ { get; set; }
        public int Code { get; set; }
        public string WXOPENID { get; set; }
    }
}