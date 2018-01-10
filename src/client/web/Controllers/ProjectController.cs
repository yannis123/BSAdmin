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
        public ProjectController(IVIPSalesService service)
        {
            _service = service;
        }
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddPreOrder()
        {
            return View();
        }
    }
}