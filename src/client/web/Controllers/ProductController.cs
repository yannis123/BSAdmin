using Domain.IService;
using Domain.Model.VIPSales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class ProductController : Controller
    {
        private IVIPSalesService _saleService = null;
        public ProductController(IVIPSalesService saleservice)
        {
            _saleService = saleservice;
        }
        public ActionResult Index(string spdm)
        {
            List<MR_SHANGPIN> list = _saleService.GetSP(spdm);

            return View(list);
        }

        public JsonResult GetProduct(string spdm)
        {
            List<MR_SHANGPIN> list = _saleService.GetSP(spdm);
            if (list != null && list.Count > 0)
            {
                return Json(new { code = 0, data = list }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { code = -1 }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}