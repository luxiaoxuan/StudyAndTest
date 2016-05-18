using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityStudy.Unity
{
    public interface IHealable
    {
        string Heal(string tar, int hp);
    }
}
