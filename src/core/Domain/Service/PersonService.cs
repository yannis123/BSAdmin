using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class PersonService
    {
        string _connectionString = string.Empty;
        public PersonService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Person Get(int id)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int personId = 1;
                Person person = cn.Get<Person>(personId);
                cn.Close();
                return person;
            }
        }

        public dynamic Insert()
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                var result = cn.Insert(new Person() { FirstName = "yannis", LastName = "yang", Active = true, DateCreated = DateTime.Now });
                cn.Close();
                return result;
            }
        }
    }
}
