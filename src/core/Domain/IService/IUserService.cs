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
        Guid AddRole(Role role);
        void AddRoleList(List<Role> roles);
        List<Role> GetRoleList();
        List<User> GetUserList();
        User GetUser(Guid id);   
        int AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(Guid id);
        User GetUser(string userName, string password);
        Role GetRole(Guid id);
    }
}

