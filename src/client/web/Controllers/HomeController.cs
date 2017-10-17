using Domain.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private IPersonService _person;
        public HomeController(IPersonService person)
        {
            _person = person;
        }
        public ActionResult Index()
        {
            var p = _person.Get(1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Empty()
        {
            return View();
        }
    }
}