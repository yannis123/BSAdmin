using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IServiceconfiguration
    {
        string DefaultConnection { get; }
        string Wx_AppId { get; }
        string Wx_AppSecret { get; }
        string Wx_RedirectUrl { get; }
    }
}
