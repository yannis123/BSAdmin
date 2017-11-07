using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models.ResponseModel
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Code = "1000";
            Success = true;
        }
        public bool Success { get; set; }
        public string Code { get; set; }
        public object Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}