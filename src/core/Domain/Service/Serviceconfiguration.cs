using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
    public class Serviceconfiguration : IServiceconfiguration
    {
        private const string DEFAULTCONNECTIONSTRING = "default";


        public string DefaultConnection
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[DEFAULTCONNECTIONSTRING].ConnectionString ?? "";
            }
           
        }
    }
}
