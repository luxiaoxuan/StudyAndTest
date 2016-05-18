using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityStudy.Unity
{
    public class TransparentAOPTarget2 : MarshalByRefObject
    {
        private string _name;


        //[InjectionConstructor]
        public TransparentAOPTarget2()
        {
            _name = "fala";
        }

        public TransparentAOPTarget2(string name)
        {
            _name = name;
        }

        public string Pray(string tarPlayer, string tarAttr)
        {
            Console.WriteLine(string.Format("{0} is prayed by {2} for {1}.", tarPlayer, tarAttr, _name));
            return string.Format("{0}'s {1} have been 25% Up.", tarPlayer, tarAttr);
        }
    }
}
