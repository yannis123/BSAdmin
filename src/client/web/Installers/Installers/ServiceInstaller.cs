using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Domain.IService;
using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Ioc.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IServiceconfiguration>() //接口  
                   .ImplementedBy<Serviceconfiguration>() //实现类 
             );

            container.Register(Component.For<IPersonService>() //接口  
                  .ImplementedBy<PersonService>() //实现类 
                  .DependsOn(Dependency.OnValue("connectionString", "DefaultConnection"))//构造函数参数
            );
           
        }
    }
}