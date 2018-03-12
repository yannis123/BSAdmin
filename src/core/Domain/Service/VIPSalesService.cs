using Domain.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.VIPSales;
using System.Data;
using DapperExtensions;
using Domain.Model;
using Dapper;
using System.Data.SqlClient;

namespace Domain.Service
{
    public class VIPSalesService : IVIPSalesService
    {

        private IDbConnection connection;
        public VIPSalesService(IDBConnectionManager conneManage)
        {
            connection = conneManage.GetDefaultConn();
        }

        public void AddSales(MR_XSJL sale)
        {
            connection.Insert<MR_XSJL>(sale);
        }

        public void AddSalesDel(MR_XSJLMX saleDel)
        {
            connection.Insert<MR_XSJLMX>(saleDel);
        }

        public List<MR_Customer> GetCustomer(string phone)
        {
            var customers = connection.Query<MR_Customer>(" select * from MR_V_CUSTOMER where sj=@sj", new { sj = phone });
            if (!customers.Any())
                return new List<MR_Customer>();
            return customers.ToList();
        }

        public List<MR_DianYuan> GetDY(string param, string khdm)
        {
            var sql = @"select * from [dbo].[MR_DIANYUAN] where KHDM='" + khdm + "' and  DYDM like '%" + param + "%' or DYMC like '%" + param + "%'";
            var dys = connection.Query<MR_DianYuan>(sql);

            if (!dys.Any())
                return new List<MR_DianYuan>();
            return dys.ToList();
        }

        public List<MR_SHANGPIN> GetSP(string SPDM)
        {
            var sps = connection.Query<MR_SHANGPIN>(
                @"select sp.SPDM,sp.SPMC,sp.BZSJ,sp1.GGDM as GG1DM,gg1.GGMC as GG1MC,sp2.GGDM as GG2DM ,gg2.GGMC as GG2MC
                    from[dbo].[MR_SHANGPIN] sp
                  left join
                    [dbo].[MR_SPGG1] sp1 on sp.SPDM = sp1.SPDM
                  left join
                    [dbo].[MR_GUIGE1]gg1 on sp1.GGDM = gg1.GGDM
                  left join
                    [dbo].[MR_SPGG2] sp2 on sp.SPDM = sp2.SPDM
                  left join
                    [dbo].[MR_GUIGE2] gg2 on sp2.GGDM = gg2.GGDM
                    where sp.spdm = @spdm", new { spdm = SPDM });
            if (!sps.Any())
                return new List<MR_SHANGPIN>();
            return sps.ToList();

        }

        public List<MR_SHANGPIN> GetProducts(string spdms)
        {
            var sps = connection.Query<MR_SHANGPIN>(
                @"select sp.SPDM,sp.SPMC,sp.BZSJ,sp1.GGDM as GG1DM,gg1.GGMC as GG1MC,sp2.GGDM as GG2DM ,gg2.GGMC as GG2MC
                    from[dbo].[MR_SHANGPIN] sp
                  left join
                    [dbo].[MR_SPGG1] sp1 on sp.SPDM = sp1.SPDM
                  left join
                    [dbo].[MR_GUIGE1]gg1 on sp1.GGDM = gg1.GGDM
                  left join
                    [dbo].[MR_SPGG2] sp2 on sp.SPDM = sp2.SPDM
                  left join
                    [dbo].[MR_GUIGE2] gg2 on sp2.GGDM = gg2.GGDM
                    where sp.spdm in @spdm", new { spdm = spdms.Split(',').ToArray() });
            if (!sps.Any())
                return new List<MR_SHANGPIN>();
            return sps.ToList();
        }

        public OrderResponse SaveOrder(OrderInfo order)
        {
            OrderResponse response = new OrderResponse() { Code = 0 };

            if (order.discountPoint == 0) order.discountPoint = 0;
            //商品总金额
            decimal spje = 0;
            string djbh = string.Empty;
            djbh = connection.ExecuteScalar<string>("select top 1 djbh from mr_xsjl order by rq desc");
            djbh = string.IsNullOrEmpty(djbh) ? "XS000000001" : "XS" + (long.Parse(djbh.Substring(2)) + 1).ToString().PadLeft(9, '0');

            string sql_getcustomer = @"select * from mr_v_customer where dm=@dm";

            string sql_xsjl = @"insert into mr_xsjl (djbh,rq,sddm,dydm,bz,zk,zkje,zje,vipdm) values (@djbh,getdate(),@sddm,@dydm,@bz,@zk,@zkje,@zje,@vipdm)";

            string sql_sxjlmx = @"insert into mr_xsjlmx (djbh,vipdm,spdm,spmc,spsl,gg1dm,gg1mc,gg2dm,gg2mc,bzsj) values (@djbh,@vipdm,@spdm,@spmc,@spsl,@gg1dm,@gg1mc,@gg2dm,@gg2mc,@bzsj)";

            using (IDbTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    //查询客户信息
                    var customer = connection.Query<MR_Customer>(sql_getcustomer, new { dm = order.gkdm }, transaction).FirstOrDefault();

                    foreach (var item in order.products)
                    {
                        var sql_product = "select * from mr_shangpin where spdm=@spdm";

                        var product = connection.QuerySingle<MR_SHANGPIN>(sql_product, new { spdm = item.spdm }, transaction);
                        spje += product.BZSJ * item.count;
                        //保存订单明细
                        connection.Execute(sql_sxjlmx, new
                        {
                            djbh = djbh,
                            vipdm = order.gkdm,
                            spdm = item.spdm,
                            spmc = product.SPMC,
                            spsl = item.count,
                            gg1dm = item.gg1dm,
                            gg1mc = item.gg1mc,
                            gg2dm = item.gg2dm,
                            gg2mc = item.gg2mc,
                            bzsj = product.BZSJ
                        }, transaction);

                    }
                    //折扣金额
                    decimal zkje = spje * Convert.ToDecimal(order.discountPoint);
                    //实际扣减金额
                    decimal zfje = spje - zkje;

                    if (customer.DQJE < zfje)
                    {
                        response.Error = "当前账户余额不足";
                        response.DQJE = customer.DQJE;
                        response.Code = -1;
                        return response;
                    }

                    //保存订单
                    connection.Execute(sql_xsjl, new { djbh = djbh, sddm = order.sddm, dydm = order.dydm, bz = "", zk = order.discountPoint, zkje = zkje, zje = zfje, vipdm = order.gkdm }, transaction);

                    //更新账户余额和消费金额
                    string sql_updatecustomer = @"update mr_v_customer set dqje=dqje-@zfje , xfje=@xfje where dm=@gkdm";
                    connection.Execute(sql_updatecustomer, new { zfje = zfje, xfje = customer.XFJE + zfje, gkdm = order.gkdm }, transaction);

                    transaction.Commit();

                    response.DQJE = customer.DQJE - zfje;
                    response.XFJE = customer.XFJE + zfje;
                    response.BCXFJE = zfje;
                    response.SJ = customer.SJ;
                    response.GKMC = customer.GKMC;
                    response.WXOPENID = customer.WXOPENID;
                }
                catch (Exception ex)
                {
                    response.Error = "提交失败";
                    response.Code = -1;
                    transaction.Rollback();
                    return response;
                }
            }
            return response;
        }

        public List<MainOrder> GetMainOrders(int pageIndex, int pageSize, out int total, string sj, string khdm, string djbh, string dydm, DateTime startdate, DateTime enddate)
        {
            string sql = @"  SELECT * FROM (
                              SELECT [MR_XSJL].* 
                              ,[MR_KEHU].KHMC
                              ,[MR_DIANYUAN].DYMC
                              ,MR_V_CUSTOMER.GKMC
                              ,MR_V_CUSTOMER.SJ
                              , ROW_NUMBER() OVER (ORDER BY [MR_XSJL].RQ DESC) rownum 
                              from  [MR_XSJL] 
                              left join [dbo].[MR_KEHU] on [MR_XSJL].SDDM=[MR_KEHU].KHDM
                              left join [dbo].[MR_DIANYUAN] on [MR_DIANYUAN].DYDM=[MR_XSJL].DYDM
                              left join MR_V_CUSTOMER on MR_V_CUSTOMER.DM=MR_XSJL.VIPDM
                               Where 1=1 {2}
                              )as b WHERE  b.rownum 
                               BETWEEN {0} AND {1}  ORDER BY b.rownum  ";

            string where = string.Empty;
            if (!string.IsNullOrEmpty(sj))
            {
                where += " and MR_V_CUSTOMER.SJ='" + sj + "'";
            }
            if (!string.IsNullOrEmpty(khdm))
            {
                where += " and MR_XSJL.SDDM='" + khdm + "'";
            }
            if (!string.IsNullOrEmpty(djbh))
            {
                where += " and MR_XSJL.DJBH='" + djbh + "'";
            }
            if (!string.IsNullOrEmpty(dydm))
            {
                where += " and MR_XSJL.DYDM='" + dydm + "'";
            }
            if (startdate != null && startdate != DateTime.MinValue)
            {
                where += " and MR_XSJL.RQ>='" + startdate.ToString() + "'";
            }
            if (enddate != null && enddate != DateTime.MinValue)
            {
                where += " and MR_XSJL.RQ<='" + enddate.ToString() + "'";
            }
            sql = string.Format(sql, (pageIndex - 1) * pageSize + 1, pageIndex * pageSize, where);

            var list = connection.Query<MainOrder>(sql).ToList();

            string countsql = @"
                              SELECT count(*)
                              from  [MR_XSJL] 
                              left join [dbo].[MR_KEHU] on [MR_XSJL].SDDM=[MR_KEHU].KHDM
                              left join [dbo].[MR_DIANYUAN] on [MR_DIANYUAN].DYDM=[MR_XSJL].DYDM
                              left join MR_V_CUSTOMER on MR_V_CUSTOMER.DM=MR_XSJL.VIPDM
                               Where 1=1 {0}";

            total = connection.ExecuteScalar<int>(string.Format(countsql, where));

            return connection.Query<MainOrder>(sql).ToList();

        }
        public List<MR_XSJLMX> GetOrderDetais(string djbh)
        {
            var predicate = Predicates.Field<MR_XSJLMX>(f => f.DJBH, Operator.Eq, djbh);
            return connection.GetList<MR_XSJLMX>(predicate).ToList();
        }
    }
}
