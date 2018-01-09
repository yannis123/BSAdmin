using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Service;
using Domain.IService;
using Domain.Model;
using System.Collections.Generic;
using Domain;

namespace UnitTestProject1
{
    [TestClass]
    public class UserService_Tset
    {
        private static IUserService _usersvc;
        private static IMRKeHuService _kehusvc;
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            IServiceconfiguration config = new Serviceconfiguration();
            IDBConnectionManager connManager = new DBConnectionManager(config);


            _usersvc = new UserService(connManager);
            _kehusvc = new MRKeHuService(connManager);

        }
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
        }

        //使用 TestInitialize 在运行每个测试前先运行代码
        [TestInitialize()]
        public void MyTestInitialize()
        {
        }

        //使用 TestCleanup 在运行完每个测试后运行代码
        [TestCleanup()]
        public void MyTestCleanup()
        {
        }
        [TestMethod]
        public void AddRole_Test()
        {
            List<Role> list = new List<Role>();

            var roles = _usersvc.GetRoleList();

            Role role_super_admin = new Role()
            {
                Id = Guid.NewGuid(),
                CreateTime = DateTime.Now,
                RoleName = "超级管理员",
            };

            Role role_admin = new Role()
            {
                Id = Guid.NewGuid(),
                CreateTime = DateTime.Now,
                RoleName = "管理员",
            };

            Role role = new Role()
            {
                Id = Guid.NewGuid(),
                CreateTime = DateTime.Now,
                RoleName = "店员",
            };
            if (!roles.Exists(m => m.RoleName == "超级管理员"))
            {
                var result = _usersvc.AddRole(role_super_admin);
                Assert.IsTrue(result == role_super_admin.Id);
            }
            if (!roles.Exists(m => m.RoleName == "管理员"))
            {
                Assert.IsTrue(_usersvc.AddRole(role_admin) != Guid.Empty);
            }
            if (!roles.Exists(m => m.RoleName == "店员"))
            {
                Assert.IsTrue(_usersvc.AddRole(role) != Guid.Empty);
            }

        }

        [TestMethod]
        public void GetKeHuList_Test()
        {
            List<MRKeHu> list = _kehusvc.GetKeHuList();
        }
    }
}
