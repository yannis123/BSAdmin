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
}