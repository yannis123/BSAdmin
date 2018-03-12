using Domain.IService;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.Models.ResponseModel;

namespace web.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _userService = null;

        private IMRKeHuService _kuhuService = null;

        public UserController(IUserService userService, IMRKeHuService kuhuService)
        {
            _userService = userService;
            _kuhuService = kuhuService;
        }
        // GET: User
        public ActionResult Index()
        {
            List<MRKeHu> kehus = _kuhuService.GetKeHuList(1, int.MaxValue, string.Empty, string.Empty);
            var users = _userService.GetUserList();

            UserViewModel model = new UserViewModel() { Kehus = kehus, Users = users };

            return View(model);
        }

        public JsonResult AddUser(User user)
        {
            if (user.RoleName == "超级管理员")
            {
                user.UserType = 1;
            }
            else if (user.RoleName == "店铺管理员")
            {
                user.UserType = 2;
            }
            user.Status = 0;
            user.CreateTime = DateTime.Now;
            BaseResponse response = new BaseResponse();
            if (_userService.AddUser(user) <= 0)
            {
                response.Success = false;
                response.ErrorMessage = "添加失败";
            }
            return Json(response);
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            List<MRKeHu> kehus = _kuhuService.GetKeHuList(1, int.MaxValue, string.Empty, string.Empty);
            var user = _userService.GetUser(id);

            UserViewModel model = new UserViewModel() { Kehus = kehus, UserModel = user };

            return View(model);
        }

        [HttpPost]
        public JsonResult EditUser(User user)
        {
            if (user.RoleName == "超级管理员")
            {
                user.UserType = 1;
            }
            else if (user.RoleName == "店铺管理员")
            {
                user.UserType = 2;
            }

            BaseResponse response = new BaseResponse();
            var model = _userService.GetUser(user.Id);
            UpdateModel<User>(model);
            if (!_userService.UpdateUser(model))
            {
                response.Success = false;
                response.ErrorMessage = "添加失败";
            }
            return Json(response);
        }


        public JsonResult AddDianYuan(MR_DianYuan dianyuan)
        {
            BaseResponse response = new BaseResponse();

            string dydm = _userService.AddDianYuan(dianyuan);

            if (string.IsNullOrEmpty(dydm))
            {
                response.Success = false;
                response.ErrorMessage = "添加失败";
            }
            response.Data = dydm;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}