using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models.RequestModel
{
    public class MainOrderListRequest
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string phoneNumber { get; set; }
        public string khdm { get; set; }
        public string djbh { get; set; }
        public string dydm { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        
    }
}