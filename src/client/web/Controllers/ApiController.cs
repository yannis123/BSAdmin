using Domain.IService;
using Domain.Model;
using Domain.Service;
using Senparc.Weixin.MP.CommonAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Filter;
using web.Models;
using web.Models.ResponseModel;

namespace web.Controllers
{
    public class ApiController : Controller
    {
        private IMRCustomerService _customer;
        private IServiceconfiguration _config;
        private IMemberService _member;
        public ApiController(IServiceconfiguration config, IMemberService member, IMRCustomerService customer)
        {
            _config = config;
            _member = member;
            _customer = customer;
         
        }
        // GET: Api
        public ActionResult Index()
        {
            string url = Senparc.Weixin.MP.AdvancedAPIs.OAuthApi.GetAuthorizeUrl(
                _config.Wx_AppId,
                _config.Wx_RedirectUrl,
                "123",
                Senparc.Weixin.MP.OAuthScope.snsapi_base
                );
            return Redirect(url);
        }

        [HttpPost]
        public JsonResult BindWeixin(RegistOpenIdRequest request)
        {
            BaseResponse response = new BaseResponse();
            if (string.IsNullOrEmpty(request.OpenId))
            {
                response.ErrorMessage = "用户微信信息获取失败！";
                return Json(response);
            }
            if (string.IsNullOrEmpty(request.PhoneNumber))
            {
                response.ErrorMessage = "请输入正确的手机号码！";
                return Json(response);
            }

            if (_customer.BindWeixin(request.PhoneNumber, request.OpenId))
            {
                return Json(new { code = 0 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { code = -1 }, JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// 获取微信用户OpenId
        /// </summary>
        /// <param name="code">authorizathon_code</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RegistOpenId(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return View("index");
            }
            try
            {
                Senparc.Weixin.MP.AdvancedAPIs.OAuth.OAuthAccessTokenResult token =
                    Senparc.Weixin.MP.AdvancedAPIs.OAuthApi.GetAccessToken(
                    _config.Wx_AppId,
                    _config.Wx_AppSecret,
                    code
                    );
                return View(token);
            }
            catch (Exception ex)
            {
                return Redirect("/api/index");
            }
        }


        public void SendTempMessage()
        {
            var openId = "odfWCxHxWWNt79R9cj0BKxXheaUc";//换成已经关注用户的openId
            var templateId = "l9gYR0d8fPw-Nlw-tXivIaFY6pzcr2Cuf_gjJtt1De0";//换成已经在微信后台添加的模板Id
            var accessToken = AccessTokenContainer.GetAccessToken(_config.Wx_AppId);

            var testData = new XFTemplateData()
            {
                //hymc = new TemplateDataItem("yannis"),
                //sj = new TemplateDataItem("18806521795"),
                //bcxfje = new TemplateDataItem("¥100.00"),
                //xfje = new TemplateDataItem("¥200.00"),
                //dqje = new TemplateDataItem("¥500.00"),
                //time = new TemplateDataItem(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"))
            };
            var result = Senparc.Weixin.MP.AdvancedAPIs.TemplateApi.SendTemplateMessage(accessToken, openId, templateId, "#FF0000", "#", testData);

        }

    }
}