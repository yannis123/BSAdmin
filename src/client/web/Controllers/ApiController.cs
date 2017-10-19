using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class ApiController : Controller
    {
        private IServiceconfiguration _config;
        public ApiController(IServiceconfiguration config)
        {
            _config = config;
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
    }
}