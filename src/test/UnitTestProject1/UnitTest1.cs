using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Domain.Service;
using Domain;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static PersonService _psv;
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            string connection = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            //_psv = new PersonService(connection);
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
        public void TestMethod1()
        {
            var id = _psv.Insert();
            Person p = _psv.Get(id);
        }
    }
}
