using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityStudy.Unity
{
    public class InterfaceAOPTarget : IHealable, IDispellable
    {
        public string Heal(string tarPlayer, int hp)
        {
            Console.WriteLine(string.Format("{0} is healed by {1} HP.", tarPlayer, hp));
            return string.Format("{0}'s HP has been full.", tarPlayer);
        }

        public string Dispel(string tarPlayer, string spell)
        {
            Console.WriteLine(string.Format("{0}'s {1} is dispelled.", tarPlayer, spell));
            return string.Format("{0} has no debuff.", tarPlayer);
        }
    }
}
