using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
    public interface IMRCustomerService
    {
        List<MR_Customer> GetCustomerList(int pageIndex, int pageSize, out int total, string phoneNumber, string khdm);
        bool AddCustomer(MR_Customer customer);
        List<MR_Customer> GetCustomerList(string khdm);
    }
}
