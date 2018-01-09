using Domain.IService;
using Domain.IService.VIPRecharge;
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
            return View();
        }
    }
}