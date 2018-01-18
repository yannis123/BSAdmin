using Domain.IService;
using Domain.Model;
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
        public ProjectController(IVIPSalesService service, IVIPRechargeService rechargeService)
        {
            _service = service;
            _rechargeService = rechargeService;
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
            //_service.AddSales();
            if (_service.SaveOrder(order))
            {
                return Json(new { code = 0 });
            }
            else
            {
                return Json(new { code = -1, eror = "保存失败" });
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