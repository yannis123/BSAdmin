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
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (_user == null)
            {
                filterContext.RequestContext.HttpContext.Response.Redirect("/account/login");
            }

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