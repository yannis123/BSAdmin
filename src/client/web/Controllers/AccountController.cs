using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using web.Models;
using Domain.IService;

namespace web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userSerice;
        public AccountController(IUserService userSerice)
        {
            _userSerice = userSerice;
        }

      
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            var user = _userSerice.GetUser(model.UserName, model.Password);
            if (user != null)
            {
                //验证成功，用户名密码正确，构造用户数据（可以添加更多数据，这里只保存用户Id）
                //var userData = new MyUserDataPrincipal { UserId = user.Id, UserName=user.UserName, RoleId=user.RoleId };
              
                //保存Cookie
                MyFormsAuthentication.SetAuthCookie(model.UserName, user, model.RememberMe);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}