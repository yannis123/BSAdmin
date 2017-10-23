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
    public class HomeController : AuthorizeController
    {
        private IMemberService _member;
        private IServiceconfiguration _config;
        public HomeController(IMemberService member, IServiceconfiguration config)
        {
            _member = member;
            _config = config;
        }
        public ActionResult Index(string code)
        {
            return View();
        }
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
        public ActionResult RegistOpenId(string openId, string phoneNumber)
        {
            Member member = _member.GetMember(phoneNumber);
            member.OpenId = openId;
            _member.UpdateMember(member);
            return View();
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