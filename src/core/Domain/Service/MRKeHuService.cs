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
        public List<Model.MRKeHu> GetKeHuList()
        {
            string sql =@"select 
                    [MR_KEHU].khdm,
                    [MR_KEHU].khmc,
                    [MR_KEHU].qydm,
                    [MR_KEHU].qddm,
                    [MR_QUDAO].qdmc,
                    [MR_QUYU].qymc 
                    from [dbo].[MR_KEHU] 
                    left join [dbo].[MR_QUDAO]
                    on [MR_KEHU].qddm=[MR_QUDAO].qddm
                    left join [dbo].[MR_QUYU]
                    on [MR_KEHU].qydm=[MR_QUYU].qydm
                    where khdm='I57133'";
            return connection.Query<MRKeHu>(sql).ToList<MRKeHu>();
        }
    }
}
