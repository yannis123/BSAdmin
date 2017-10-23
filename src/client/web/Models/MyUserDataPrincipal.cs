using Domain;
using Domain.IService;
using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace web.Models
{
    public class MyUserDataPrincipal : IPrincipal
    {
        //数据源
        private readonly UserService userSvc = new UserService(new DBConnectionManager(new Serviceconfiguration()));

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        //这里可以定义其他一些属性
        public Guid RoleId { get; set; }

        //当使用Authorize特性时，会调用改方法验证角色 
        public bool IsInRole(string role)
        {
            //找出用户所有所属角色
            //var userroles = mingshiDb.UserRole.Where(u => u.UserId == UserId).Select(u => u.Role.RoleName).ToList();

            var userroles = userSvc.GetRoleList().Select(m => m.RoleName);

            var roles = role.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return (from s in roles from userrole in userroles where s.Equals(userrole) select s).Any();
        }

        //验证用户信息
        public bool IsInUser(string user)
        {
            //找出用户所有所属角色
            var users = user.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //return mingshiDb.User.Any(u => users.Contains(u.UserName));
            return userSvc.GetUserList().Any(m => users.Contains(m.UserName));
        }


        [ScriptIgnore]    //在序列化的时候忽略该属性
        public IIdentity Identity
        {
            get;set;
        }
    }
}