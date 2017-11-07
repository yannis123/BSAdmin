using Domain.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IDBConnectionManager
    {
        IDbConnection GetDefaultConn();
    }


    public class DBConnectionManager : IDBConnectionManager
    {
        private IServiceconfiguration _config;
        public DBConnectionManager(IServiceconfiguration config)
        {
            _config = config;
        }

        public IDbConnection GetDefaultConn() //获取sql数据库连接，这边你可以用MySql、SQLlite等五种数据库Connection
        {
            try
            {
                SqlConnection conn = new SqlConnection(_config.DefaultConnection);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IDbConnection GetBSConn()
        {
            try
            {
                SqlConnection conn = new SqlConnection(_config.DefaultConnection);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
