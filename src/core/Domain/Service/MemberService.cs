using Domain.IService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;
using Domain.Model;

namespace Domain.Service
{
    public class MemberService : IMemberService
    {
        private IDbConnection connection;
        public MemberService(IDBConnectionManager connManager)
        {
            connection = connManager.GetDefaultConn();
        }
        public Guid InsertMember(Model.Member model)
        {
            return connection.Insert(model);
        }

        public bool UpdateMember(Model.Member model)
        {
            return connection.Update(model);
        }

        public Model.Member GetMember(Guid id)
        {
            return connection.Get<Member>(id);
        }

        public List<Model.Member> GetMemberList()
        {
            return connection.GetList<Member>().ToList();
        }


        public Member GetMember(string phoneNumber)
        {
            return connection.GetList<Member>(new Member() { Phone = phoneNumber }).FirstOrDefault();
        }
    }
}
