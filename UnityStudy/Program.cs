using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityStudy.Unity;

namespace UnityStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestUnityTransparentAOP();
            TestUnityInterfaceAOP();

            Console.Read();
        }

        private static void TestUnityTransparentAOP()
        {
            // By app.config
            var hakuContainer = new UnityContainer();
            (ConfigurationManager.GetSection("rai") as UnityConfigurationSection).Configure(hakuContainer, "haku");

            var tar = hakuContainer.Resolve<TransparentAOPTarget>();
            tar.Pray("ygk", "MDF");


            // By code 1
            var c = new UnityContainer();
            c.AddNewExtension<Interception>();
            c.RegisterType<TransparentAOPTarget>(
                new Interceptor<TransparentProxyInterceptor>(),
                new InterceptionBehavior<MyInterception>()
            );

            var tar1 = c.Resolve<TransparentAOPTarget>();
            tar1.Pray("fangwa", "ATK");


            // By code 2
            c.RegisterType<TransparentAOPTarget2>(
                new Interceptor<TransparentProxyInterceptor>(),
                new InterceptionBehavior<MyInterception>()
            );

            var tar2 = c.Resolve<TransparentAOPTarget2>(new ParameterOverrides { { "name", "mikoto" } });
            tar2.Pray("daoshen", "SPD");
        }

        private static void TestUnityInterfaceAOP()
        {
            var c = new UnityContainer();

            // By app.config
            (ConfigurationManager.GetSection("rai") as UnityConfigurationSection).Configure(c, "haku");

            var tar1 = c.Resolve<IHealable>();
            tar1.Heal("ygk", 9000);


            // By code 1
            c = new UnityContainer();
            c.AddNewExtension<Interception>();
            c.RegisterType<IHealable, InterfaceAOPTarget>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<MyInterception>()
            );

            var tar2 = c.Resolve<IHealable>();
            tar2.Heal("ygk", 35000);

            c = new UnityContainer();
            c.AddNewExtension<Interception>();
            c.RegisterType<IDispellable, InterfaceAOPTarget>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<MyInterception>()
            );

            var tar3 = c.Resolve<IDispellable>();
            tar3.Dispel("cnc", "pain");



            c = new UnityContainer();
            c.AddNewExtension<Interception>();
            c.RegisterType<InterfaceAOPTarget>(
                //new Interceptor<InterfaceInterceptor>(),
                //new InterceptionBehavior<MyInterception>()
            );
            var tar4 = c.Resolve<InterfaceAOPTarget>();
            tar4.Dispel("kamiu", "pain");
        }
    }
}
