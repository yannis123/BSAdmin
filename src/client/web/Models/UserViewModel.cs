using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class UserViewModel
    {
        public List<MRKeHu> Kehus { get; set; }
        public List<User> Users { get; set; }
        public User UserModel { get; set; }
    }
}