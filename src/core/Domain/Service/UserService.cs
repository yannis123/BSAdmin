using Domain.IService;
using DapperExtensions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using System.Data;

namespace Domain.Service
{
    public class UserService : IUserService
    {

        private IDbConnection connection;
        public UserService(IDBConnectionManager connManager)
        {
            connection = connManager.GetDefaultConn();
        }


        public Guid AddRole(Role role)
        {
            return connection.Insert(role);

        }

        public void AddRoleList(List<Role> roles)
        {
            connection.Insert(roles);
        }

        public List<Role> GetRoleList()
        {
            List<Role> list = new List<Role>();
            //list.Add(new Role() { Id = Guid.Parse("cd9674fe-b353-491e-9da1-2868ebe57a2f"), RoleName = "超级管理员" });
            //list.Add(new Role() { Id = Guid.Parse("cd9674fe-b353-491e-9da1-2868ebe57a2f"), RoleName = "管理员" });
            //return list;
            return connection.GetList<Role>().ToList();
        }

        public List<User> GetUserList()
        {
            //List<User> list = new List<Model.User>();
            //list.Add(new User() { UserName = "yannis", CreateTime = DateTime.Now, Id = Guid.Parse("cd9674fe-b353-491e-9da1-2868ebe57a2f"), Password = "123", Status = 1});
            //list.Add(new User() { UserName = "yanght", CreateTime = DateTime.Now, Id = Guid.Parse("ea60d9c7-d522-42b2-8a9f-ff8009fa0cf3"), Password = "123", Status = 1 });
            //return list;

            var predicate = Predicates.Field<User>(m=>m.Status, Operator.Eq, 1);

            return connection.GetList<User>(predicate).ToList();
        }

        public User GetUser(Guid id)
        {
            return connection.Get<User>(id);
        }

        public int AddUser(User user)
        {
            return connection.Insert<User>(user);
        }

        public bool UpdateUser(User user)
        {
            return connection.Update<User>(user);
        }

        public bool DeleteUser(Guid id)
        {
            return connection.Delete<User>(id);
        }
        public User GetUser(string userName, string password)
        {
            //return new User() { Id = Guid.Parse("cd9674fe-b353-491e-9da1-2868ebe57a2f"), CreateTime = DateTime.Now, Password = "123", Status = 1, UserName = "yannis"};
            string sql = "select * from [User] where username=@username and password=@password";
            return connection.Query<User>(sql, new { userName = userName, password = password }).SingleOrDefault();
        }

        public Role GetRole(Guid id)
        {
            //return new Role() { Id = Guid.Parse("cd9674fe-b353-491e-9da1-2868ebe57a2f"), RoleName = "超级管理员" };
            return connection.Get<Role>(id);
        }
    }
}
