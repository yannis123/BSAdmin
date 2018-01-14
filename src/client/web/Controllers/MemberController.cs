using Domain.IService;
using Domain.IService;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class MemberController : BaseController
    {
        private IVIPRechargeService _service;
        private IMRCustomerService _customer;
        public MemberController(IVIPRechargeService rechargeService, IMRCustomerService customer)
        {
            _service = rechargeService;
            _customer = customer;
        }
        // GET: Member
        public ActionResult Index()
        {
            // var list = _customer.GetCustomerList(0, 0);

            return View();
        }

        public ActionResult Recharge(string vipdm)
        {
            var archives = _service.GetArchives();
            ViewBag.Archives = archives;
            ViewBag.vipdm = vipdm;
            return View();
        }

        [HttpPost]
        public JsonResult Recharge(string czdm, string vipdm)
        {
            if (_service.AddRecharge(vipdm, czdm, UserInfo.DYDM, UserInfo.KHDM))
            {
                return Json(new { code = 0 });
            }
            else
            {
                return Json(new { code = -1 });
            }
        }

        #region  get raw data

        public JsonResult CustomerList(int pageNumber, int pageSize, string phoneNumber)
        {
            int total = 0;
            var list = _customer.GetCustomerList(pageNumber, pageSize, out total, phoneNumber);
            return Json(new { rows = list, total = total }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetArchive(string czdm)
        {
            var model = _service.GetArchive(czdm);

            return Json(new { code = 0, data = model }, JsonRequestBehavior.AllowGet);
        }



        #endregion
    }
}