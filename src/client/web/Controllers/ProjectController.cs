using Domain.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class ProjectController : BaseController
    {
        private IVIPSalesService _service;
        private IVIPRechargeService _rechargeService;
        public ProjectController(IVIPSalesService service,IVIPRechargeService rechargeService)
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
           ViewBag.DianYuan= _rechargeService.GetDianYuanList(UserInfo.KHDM);

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

    }
}