using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using web.Models;
using System.Web.Routing;

namespace web.Controllers
{
    public class AuthorizeController : Controller
    {
        public User UserInfo
        {
            get
            {
                return MyFormsAuthentication.GetAuthCookie();
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (this.UserInfo == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                    filterContext.Result = new JsonResult
                    {
                        Data = new
                        {
                            Error = "NotAuthorized",
                            LogOnUrl = urlHelper.Action("Login", "Account")
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    filterContext.Result = RedirectToAction("Login", "Account");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}