using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("A:" + JTC.A);
            JTB.Go();

            Console.Read();
        }
    }

    public class JTA
    {
        //First
        public static readonly int x = 2;

        //Second
        static JTA()
        {
            x = JTB.y + 1;
        }
    }

    public class JTB
    {
        //First
        public static int y = JTA.x + 1;

        //Second
        public static void Go()
        {
            Console.WriteLine("x:{0},y:{1}。", JTA.x, y);
        }

        public static int GoGo()
        {
            return JTA.x;
        }
    }

    public class JTC
    {

        public static int B = 2;
        public static int A = B;
    }
}
