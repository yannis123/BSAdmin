using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
    public interface IUserService
    {

        List<User> GetUserList();
        User GetUser(Guid id);
        int AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(Guid id);
        User GetUser(string userName, string password);
        MR_DianYuan GetDianYuan(string khdm, string dlmm);

    }
}


