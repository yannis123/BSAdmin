using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Member
    {
        public Guid Id { get; set; }
        public string ReferId { get; set; }
        public string OpenId { get; set; }
        public string VipCode { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public decimal AccountBalance { get; set; }
        public int Score { get; set; }
        public bool IsFollow { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
    }
}
