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
    public class HomeController : Controller
    {
      
        private IServiceconfiguration _config;
        public HomeController( IServiceconfiguration config)
        {
            _config = config;
        }
        public ActionResult Index(string code)
        {
            return View();
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


        [MyAuthorize(Roles = "User", Users = "bomo,toroto")]
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