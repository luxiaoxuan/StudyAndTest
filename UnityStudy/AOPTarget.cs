using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityStudy
{
    public class AOPTarget : MarshalByRefObject
    {
        public string Pray(string tarPlayer, string tarAttr)
        {
            Console.WriteLine(string.Format("{0} is prayed for {1}.", tarPlayer, tarAttr));
            return string.Format("{0}'s {1} have been 25% Up.", tarPlayer, tarAttr);
        }
    }
}
