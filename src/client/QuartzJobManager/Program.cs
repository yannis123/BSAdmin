using Castle.Windsor;
using Castle.Windsor.Installer;
using Senparc.Weixin.MP.CommonAPIs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace QuartzJobManager
{
    class Program
    {
        private static IWindsorContainer container;

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
            BootstrapContainer();

            try
            {
                AccessTokenContainer.Register(System.Configuration.ConfigurationManager.AppSettings["AppId"] ?? "", System.Configuration.ConfigurationManager.AppSettings["AppSecret"] ?? "");
            }
            catch (Exception e)
            {

            }

            HostFactory.Run(x =>
            {
              
                x.UseLog4Net();

                x.Service<ServiceRunner>();

                x.SetDescription("QuartzDemo服务描述");
                x.SetDisplayName("QuartzDemo服务显示名称");
                x.SetServiceName("QuartzDemo服务名称");

                x.EnablePauseAndContinue();
            });
        }

        static void BootstrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This());

        }


    }
}
