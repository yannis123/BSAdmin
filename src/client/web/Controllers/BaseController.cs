using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class BaseController : Controller
    {
        private User _user;
        public BaseController()
        {
            _user = MyFormsAuthentication.GetAuthCookie();
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        public User UserInfo
        {
            get
            {
                return _user;
            }
        }
    }
}