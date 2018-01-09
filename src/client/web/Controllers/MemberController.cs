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
        public MemberController(IVIPRechargeService rechargeService)
        {
            _service = rechargeService;
        }
        // GET: Member
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Recharge()
        {
            var archives = _service.GetArchives();
            ViewBag.Archives = archives;
            return View();
        }
        [HttpPost]
        public ActionResult Recharge(MR_CCJLMX rechargeDlt)
        {
            var rechargeLst = new List<MR_CCJL>();
            var recharge = new MR_CCJL()
            {
                DJBH = Guid.NewGuid().ToString(),
                DYDM = "",
                SDDM = "",
                RQ = DateTime.Now,
                BZ = string.Empty

            };
            rechargeLst.Add(recharge);
            _service.AddRecharges(rechargeLst);


            var rechargeDelLst = new List<MR_CCJLMX>();
            rechargeDelLst.Add(rechargeDlt);
            _service.AddRechargeDtl(rechargeDelLst);

            return View();
        }
    }
}