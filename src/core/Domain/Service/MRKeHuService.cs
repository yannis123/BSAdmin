using Domain.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using Domain.Model;

namespace Domain.Service
{
    public class MRKeHuService : IMRKeHuService
    {
        private IDbConnection connection;
        public MRKeHuService(IDBConnectionManager connManager)
        {
            connection = connManager.GetDefaultConn();
        }
        public List<Model.MRKeHu> GetKeHuList(int pageIndex, int pageSize, string khdm, string khmc)
        {
            string sql = @"SELECT * FROM 
                        (SELECT 
                        [MR_KEHU].khdm,
                        [MR_KEHU].khmc,
                        [MR_KEHU].qydm,
                        [MR_KEHU].qddm,
                        [MR_KEHU].tzsy,
                        [MR_QUDAO].qdmc,
                        [MR_QUYU].qymc 
                        , ROW_NUMBER()
                         OVER (ORDER BY [MR_KEHU].khdm) rownum FROM 
                         [dbo].[MR_KEHU] 
                        left join [dbo].[MR_QUDAO]
                        on [MR_KEHU].qddm=[MR_QUDAO].qddm
                        left join [dbo].[MR_QUYU]
                        on [MR_KEHU].qydm=[MR_QUYU].qydm  
                         )
                        b WHERE b.TZSY=0 and b.rownum 
                        BETWEEN {0} AND {1} {2} ORDER BY b.rownum";

            string where = string.Empty;
            if (!string.IsNullOrEmpty(khdm))
            {
                where += " and b.khdm='" + khdm + "'";
            }
            if (!string.IsNullOrEmpty(khmc))
            {
                where += " and b.khmc like '%" + khmc + "%'";
            }

            sql = string.Format(sql, (pageIndex - 1) * pageSize + 1, pageIndex * pageSize, where);

            return connection.Query<MRKeHu>(sql).ToList<MRKeHu>();
        }
    }
}
