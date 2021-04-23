using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveArithmeticProgression
{
    class Program
    {
        static void Main(string[] args)
        {
            RecursiveAP(2, 3, 10);
            Console.ReadKey();
        }

        static void RecursiveAP(int firstItem, int ratio, int repeatLength)
        {
            if (repeatLength > 0)
            {
                RecursiveAP(firstItem, ratio, repeatLength - 1);
                Console.WriteLine("a{0} = {1} + {2} = {3}", repeatLength, ratio * repeatLength - 1, ratio, firstItem + (ratio * repeatLength));
            }
        }
    }
}
