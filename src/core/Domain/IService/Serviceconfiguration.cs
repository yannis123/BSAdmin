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
        private const string DNCONNECTIONSTRING = "default";


        public string DBConnection
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[DNCONNECTIONSTRING].ConnectionString ?? "";
            }
           
        }
    }
}
