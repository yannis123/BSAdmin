using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
    public interface IMemberService
    {
        Guid InsertMember(Member model);
        bool UpdateMember(Member model);
        Member GetMember(Guid id);
        Member GetMember(string phoneNumber);
        List<Member> GetMemberList();
    }
}
