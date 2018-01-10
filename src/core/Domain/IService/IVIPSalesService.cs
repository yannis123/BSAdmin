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
    }
}
