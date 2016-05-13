using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            var uSection = ConfigurationManager.GetSection("raiSection") as UnityConfigurationSection;
            var container = new UnityContainer();
            uSection.Configure(container, "hakuContainer");

            var tar = container.Resolve<AOPTarget>();
            tar.Pray("ygk", "MDF");

            Console.Read();
        }
    }
}
