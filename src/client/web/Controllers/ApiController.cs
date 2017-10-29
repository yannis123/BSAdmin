using Domain.IService;
using Domain.Model;
using Domain.Service;
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
    public class ApiController : BaseController
    {
        private IServiceconfiguration _config;
        private IMemberService _member;
        public ApiController(IServiceconfiguration config, IMemberService member)
        {
            _config = config;
            _member = member;
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
        public JsonResult RegistOpenId(RegistOpenIdRequest request)
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

            Member member = _member.GetMember(request.PhoneNumber);

            if (member == null)
            {
                response.ErrorMessage = "没有该会员信息";
                return Json(response);
            }
            member.OpenId = request.OpenId;
            if (!_member.UpdateMember(member))
            {
                response.ErrorMessage = "绑定失败！";
                return Json(response);
            }
            return Json(response);
        }


    }
}