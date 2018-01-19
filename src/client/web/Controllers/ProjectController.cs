using Domain.IService;
using Domain.Model;
using Domain.Service;
using Senparc.Weixin.MP.CommonAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models.RequestModel;

namespace web.Controllers
{
    public class ProjectController : BaseController
    {
        private IVIPSalesService _service;
        private IVIPRechargeService _rechargeService;
        private IServiceconfiguration _config;
        public ProjectController(IServiceconfiguration config, IVIPSalesService service, IVIPRechargeService rechargeService)
        {
            _service = service;
            _rechargeService = rechargeService;
            _config = config;
        }
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddPreOrder()
        {
            ViewBag.DianYuan = _rechargeService.GetDianYuanList(UserInfo.KHDM);

            //var dy = _service.GetDY("020020", UserInfo.KHDM);
            //var vip = _service.GetCustomer("13868197428");
            var sp = _service.GetSP("015216040");
            return View(sp);
        }

        public ActionResult AddProject()
        {
            var dyList = _service.GetDY("020020", UserInfo.KHDM);
            ViewBag.DYList = dyList;
            //var vip = _service.GetCustomer("13868197428");
            var sp = _service.GetSP("015216040");
            return View(sp);
        }

        public ActionResult MainOrderList()
        {
            return View();
        }

        public ActionResult OrderDetail(string djbh)
        {
            var list = _service.GetOrderDetais(djbh);
            return View(list);
        }


        [HttpPost]
        public JsonResult AddPreOrder(OrderInfo order)
        {
            if (order.discountPoint < 0 || order.discountPoint >= 1)
            {
                return Json(new { code = -1, error = "折扣值为0-1" });
            }
            if (string.IsNullOrEmpty(order.gkdm))
            {
                return Json(new { code = -1, error = "请选择会员" });
            }
            if (string.IsNullOrEmpty(order.dydm))
            {
                return Json(new { code = -1, error = "请选择店员" });
            }
            if (order.products == null || order.products.Count == 0)
            {
                return Json(new { code = -1, error = "请选择商品" });
            }
            order.sddm = UserInfo.KHDM;
            var orderResponse = _service.SaveOrder(order);
            if (orderResponse.Code == 0)
            {
                try
                {
                    var openId = orderResponse.WXOPENID;//"odfWCxHxWWNt79R9cj0BKxXheaUc";//换成已经关注用户的openId
                    var templateId = _config.WX_TemplateMessageId;//"l9gYR0d8fPw-Nlw-tXivIaFY6pzcr2Cuf_gjJtt1De0";//换成已经在微信后台添加的模板Id
                    var accessToken = AccessTokenContainer.GetAccessToken(_config.Wx_AppId);

                    string message = "您本次消费后账户充值余额剩余{0}元 \r\n历次拿货消费总金额为{1}元 \r\n{2}";

                    var testData = new XFTemplateData()
                    {
                        productType = new TemplateDataItem("会员名称", "#000000"),
                        name = new TemplateDataItem(orderResponse.GKMC),
                        accountType = new TemplateDataItem("金额", "#000000"),
                        account = new TemplateDataItem("¥" + orderResponse.BCXFJE.ToString("f2")),
                        time = new TemplateDataItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        remark = new TemplateDataItem(string.Format(message, orderResponse.DQJE.ToString("f2"), orderResponse.XFJE.ToString("f2"), "祝您购物愉快!"))

                    };
                    var result = Senparc.Weixin.MP.AdvancedAPIs.TemplateApi.SendTemplateMessage(accessToken, openId, templateId, "#FF0000", "", testData);
                }
                catch (Exception ex)
                {
                    return Json(new { code = -1, error=ex.Message+","+ orderResponse.WXOPENID });
                }
                return Json(new { code = 0, data = orderResponse });
            }
            else
            {
                return Json(new { code = -1, error = orderResponse.Error });
            }
        }

        public JsonResult GetMainOrderList(MainOrderListRequest request)
        {
            int total = 0;

            var list = _service.GetMainOrders(request.pageNumber, request.pageSize, out total, request.phoneNumber, UserInfo.KHDM, request.djbh, request.dydm, request.startdate, request.enddate);

            return Json(new { rows = list, total = total }, JsonRequestBehavior.AllowGet);

        }


    }
}