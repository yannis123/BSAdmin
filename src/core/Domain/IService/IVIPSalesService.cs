﻿using Domain.Model;
using Domain.Model.VIPSales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
    public interface IVIPSalesService
    {
        void AddSales(MR_XSJL sale);
        void AddSalesDel(MR_XSJLMX saleDel);

        List<MR_Customer> GetCustomer(string phone);
        List<MR_DianYuan> GetDY(string param, string khdm);
        List<MR_SHANGPIN> GetSP(string SPDM);
        List<MR_SHANGPIN> GetProducts(string spdms);
        OrderResponse SaveOrder(OrderInfo order);
        List<MainOrder> GetMainOrders(int pageIndex, int pageSize, out int total, string sj, string khdm, string djbh, string dydm, DateTime startdate, DateTime enddate);
        List<MR_XSJLMX> GetOrderDetais(string djbh);

    }
}
