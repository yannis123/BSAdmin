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
    public class StoreController : BaseController
    {
        private IMRKeHuService _kehuService = null;
        public StoreController(IMRKeHuService kehuService)
        {
            _kehuService = kehuService;
        }
        // GET: Store
        public ActionResult Index(KeHuRequest request)
        {
            List<MRKeHu> list = _kehuService.GetKeHuList(1,int.MaxValue,request.KHDM,request.KHMC);
            return View(list);
        }
    }
}