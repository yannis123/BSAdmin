using Domain;
using Domain.IService;
using Domain.Model;
using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using System.Web.Routing;

namespace web.Filter
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class AuthFilterrAttribute : ActionFilterAttribute
    {
        public string RoleName { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            MR_DianYuan user = MyFormsAuthentication.GetAuthCookie();

            #region 未登录
            if (user == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                    filterContext.Result = new JsonResult
                    {
                        Data = new
                        {
                            Error = "用户未登陆",
                            LogOnUrl = urlHelper.Action("Login", "Account")
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                   
                }
                else
                {
                    filterContext.Result = new RedirectResult("/Account/Login");
                }
                return;
            }
            #endregion

            #region 没有权限
        
            //UserService userService = new UserService(new DBConnectionManager(new Serviceconfiguration()));
            //Role role = userService.GetRole(Guid.NewGuid());
            //if (!string.IsNullOrEmpty(this.RoleName) && !this.RoleName.Split(',').Contains(role.RoleName))
            //{
            //    if (filterContext.HttpContext.Request.IsAjaxRequest())
            //    {
            //        UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
            //        filterContext.Result = new JsonResult
            //        {
            //            Data = new
            //            {
            //                Error = "没有权限",
            //                LogOnUrl = urlHelper.Action("NoPromission", "Account")
            //            },
            //            JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //        };
            //    }
            //    else
            //    {
            //        filterContext.Result = new RedirectResult("/Account/NoPromission");
            //    }
            //    return;
            //}
            #endregion

            base.OnActionExecuting(filterContext);
        }
    }
}