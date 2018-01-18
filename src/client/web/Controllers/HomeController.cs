using Domain.IService;
using Domain.Model;
using Domain.Service;
using Senparc.Weixin.MP.AppStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{

    public class HomeController : BaseController
    {
        private IMRCustomerService _customer;
        private IServiceconfiguration _config;
        public HomeController(IServiceconfiguration config, IMRCustomerService customer)
        {
            _customer = customer;
            _config = config;
        }
        public ActionResult Index(string code)
        {
            return View(this.UserInfo);
        }

        /// <summary>
        /// 获取微信用户OpenId
        /// </summary>
        /// <param name="code">authorizathon_code</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RegistOpenId(string code)
        {
            Senparc.Weixin.MP.AdvancedAPIs.OAuth.OAuthAccessTokenResult token =
                Senparc.Weixin.MP.AdvancedAPIs.OAuthApi.GetAccessToken(
                _config.Wx_AppId,
                _config.Wx_AppSecret,
                code
                );
            return View(token);
        }

        [HttpPost]
        public JsonResult BindOpenId(string phoneNumber, string openId)
        {
            if (_customer.BindWeixin(phoneNumber, openId))
            {
                return Json(new { code = 0 });
            }
            return Json(new { code = -1 });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Empty()
        {
            return View();
        }
    }
}