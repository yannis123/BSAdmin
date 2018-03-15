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



        public List<User> GetUserList()
        {
            var predicate = Predicates.Field<User>(m => m.Status, Operator.Eq, 0);
            predicate = null;
            return connection.GetList<User>(predicate).ToList();
        }

        public User GetUser(int id)
        {
            return connection.Get<User>(id);
        }

        public int AddUser(User user)
        {
            int count = connection.ExecuteScalar<int>("select count(*) from [user] where username=@username", new { username = user.UserName , usertype =user.UserType});

            if (count > 0)
            {
                return 0;
            }

            return connection.Insert<User>(user);
        }

        public bool UpdateUser(User user)
        {
            int count = connection.ExecuteScalar<int>("select count(*) from [user] where username=@username", new { username = user.UserName, usertype = user.UserType });

            if (count >1)
            {
                return false;
            }
            return connection.Update<User>(user);
        }

        public bool DeleteUser(int id)
        {
            return connection.Delete<User>(id);
        }
        public User GetUser(string userName, string password)
        {
            //return new User() { Id = Guid.Parse("cd9674fe-b353-491e-9da1-2868ebe57a2f"), CreateTime = DateTime.Now, Password = "123", Status = 1, UserName = "yannis"};
            string sql = "select * from [User] where username=@username and password=@password and status=0";
            return connection.Query<User>(sql, new { userName = userName, password = password }).SingleOrDefault();
        }

        public MR_DianYuan GetDianYuan(string khdm, string dlmm)
        {
            string sql = @"select top 1 * from [MR_DIANYUAN]
                            left join [dbo].[MR_KEHU] on [MR_DIANYUAN].KHDM=[MR_KEHU].KHDM
	                        left join MR_QUDAO on MR_QUDAO.QDDM=[MR_KEHU].QDDM
	                        left join MR_QUYU on MR_QUYU.QYDM=[MR_KEHU].QYDM
                            where MR_DIANYUAN.KHDM=@KHDM and MR_DIANYUAN.DLMM=@DLMM";
            return connection.Query<MR_DianYuan>(sql, new { KHDM = khdm, DLMM = dlmm }).SingleOrDefault();
        }

        public string AddDianYuan(MR_DianYuan dianyuan)
        {
            string dydm = string.Empty;

            string maxDydm = connection.QuerySingleOrDefault("select top 1 dydm from [MR_DIANYUAN] where dydm like 'A%' order by dydm desc");

            if (string.IsNullOrEmpty(maxDydm))
            {
                dydm = "A" + dydm.PadLeft(5, '0');
            }
            else
            {
                dydm = "A" + (int.Parse(dydm.Substring(1, dydm.Length - 1)) + 1).ToString().PadLeft(5, '0');
            }
            dianyuan.ISADMIN = true;
            dianyuan.DYDM = dydm;

            return connection.Insert<MR_DianYuan>(dianyuan);
        }
    }
}
