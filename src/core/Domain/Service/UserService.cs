using Domain.IService;
using DapperExtensions;
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
            return connection.GetList<Role>().ToList();
        }

        public List<User> GetUserList()
        {
          return   connection.GetList<User>().ToList();
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
    }
}
