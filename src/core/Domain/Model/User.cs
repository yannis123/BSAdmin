using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public string RoleName { get; set; }
        public int UserType { get; set; }
        public string StoreNumber { get; set; }
        public string StoreName { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
