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
            var diayuns = _service.GetDianYuanList(UserInfo.KHDM);
            ViewBag.Archives = archives;
            ViewBag.vipdm = vipdm;
            ViewBag.DianYuans = diayuns;
            return View();
        }

        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddMember(MR_Customer model)
        {
            model.KHDM = UserInfo.KHDM;
            model.GDR = UserInfo.KHMC;
            model.XGRQ = DateTime.Now;
            if (_customer.AddCustomer(model))
            {
                return Json(new { code = 0 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { code = -1, }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult RechargeRecord()
        {
            return View();
        }
        #region  get raw data

        [HttpPost]
        public JsonResult Recharge(string czdm, string vipdm, string dydm)
        {
            if (_service.AddRecharge(vipdm, czdm, dydm, UserInfo.KHDM))
            {
                return Json(new { code = 0 });
            }
            else
            {
                return Json(new { code = -1 });
            }
        }


        public JsonResult CustomerList(int pageNumber, int pageSize, string phoneNumber)
        {
            int total = 0;
            var list = _customer.GetCustomerList(pageNumber, pageSize, out total, phoneNumber, UserInfo.KHDM);
            return Json(new { rows = list, total = total }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetArchive(string czdm)
        {
            var model = _service.GetArchive(czdm);

            return Json(new { code = 0, data = model }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRechargeRocord(int pageNumber, int pageSize, string phoneNumber)
        {
            int total = 0;
            var list = _service.GetRechargeList(pageNumber, pageSize, out total, UserInfo.KHDM, phoneNumber);
            return Json(new { rows = list, total = total }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomer(string phoneNumber)
        {
            var customer = _customer.GetCustomer(UserInfo.KHDM,phoneNumber);
            if (customer != null)
            {
                return Json(new { code = 0, data = customer }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { code = -1 }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}