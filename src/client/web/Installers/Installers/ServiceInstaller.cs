using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Domain;
using Domain.IService;
using Domain.IService;
using Domain.Service;
using Domain.Service.VIPRecharge;
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
            //Castle容器的组件生存周期，主要有如下几种
            //1.Singleton: 容器中只有一个实例将被创建
            //2.Transient : 每次请求创建一个新实例
            //3.PerThread: 每线程中只存在一个实例
            //4.PerWebRequest : 每次web请求创建一个新实例
            //5.Pooled ：使用"池化"方式管理组件，可使用PooledWithSize方法设置池的相关属性

            container.Register(Component.For<IServiceconfiguration>() //接口  
                   .ImplementedBy<Serviceconfiguration>()
                   .LifestyleSingleton() //实现类 
             );

            container.Register(Component.For<IUserService>() //接口  
                  .ImplementedBy<UserService>() //实现类 
                  .LifestyleSingleton()
            );

            container.Register(Component.For<IMemberService>() //接口  
                 .ImplementedBy<MemberService>() //实现类 
                 .LifestyleSingleton()
           );

            container.Register(Component.For<IMRKeHuService>() //接口  
                .ImplementedBy<MRKeHuService>() //实现类 
                .LifestyleSingleton()
          );

            container.Register(Component.For<IDBConnectionManager>() //接口  
                 .ImplementedBy<DBConnectionManager>() //实现类 
                 .LifestyleSingleton()
           );

            container.Register(Component.For<IMRCustomerService>() //接口  
               .ImplementedBy<MRCustomerService>() //实现类 
               .LifestyleSingleton()
         );


            #region VIPRecharge
            container.Register(Component.For<IVIPRechargeService>() //接口  
                .ImplementedBy<VIPRehargeService>() //实现类 
                .LifestyleSingleton()
          );
            #endregion



            #region VIPSales
            container.Register(Component.For<IVIPSalesService>() //接口  
                    .ImplementedBy<VIPSalesService>() //实现类 
                    .LifestyleSingleton()
              );
            #endregion


            container.Register(Component.For<IScheduleJobsService>() //接口  
          .ImplementedBy<ScheduleJobsService>() //实现类 
          .LifestyleSingleton()
    );


            //container.Register(Component.For(typeof(IRepository<>)) //接口  
            //       .ImplementedBy(typeof(Repository<>)) //实现类 
            //       .LifestyleSingleton()
            // );

        }
    }
}