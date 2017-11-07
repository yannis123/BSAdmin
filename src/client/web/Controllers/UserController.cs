using Domain.IService;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models.ResponseModel;

namespace web.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _userService = null;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: User
        public ActionResult Index()
        {
            _userService.GetUserList();
            return View();
        }

        public JsonResult AddUser(User user)
        {
            BaseResponse response = new BaseResponse();
            if (_userService.AddUser(user) <= 0)
            {
                response.Success = false;
                response.ErrorMessage = "添加失败";
            }
            return Json(response);
        }

    }
}