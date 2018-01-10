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

namespace web.Filter
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        private string[] roles;
        public PermissionAttribute(params string[] role)
        {
            roles = role;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //MR_DianYuan user = MyFormsAuthentication.GetAuthCookie();

            //if (user == null) return false;

            //if (string.IsNullOrEmpty(user.RoleName)) return false;

            //if (roles == null || roles.Count() == 0) return false;

            //return roles.Contains(user.RoleName);
            return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                filterContext.Result = new JsonResult
                {
                    Data = new
                    {
                        Error = "没有权限",
                        LogOnUrl = urlHelper.Action("Login", "Account")
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}