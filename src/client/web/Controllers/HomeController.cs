using Domain.IService;
using Domain.Repositories;
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
        private IUserService _usersvc;

        public HomeController(IUserService usersvc)
        {
            _usersvc = usersvc;
        }
        public ActionResult Index()
        {
            var roles = _usersvc.GetRoleList();
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