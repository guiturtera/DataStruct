using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveMathPow
{
    class Program
    {
        // Obs -> for positive exponents
        static void Main(string[] args)
        {
            LogPowAnswer(2, 2);
            LogPowAnswer(3, 3);
            LogPowAnswer(3, 4);
            LogPowAnswer(5, 3);
            LogPowAnswer(10, 3);
            LogPowAnswer(6, 2);
            Console.ReadKey();
        }

        // Writing variables like this only for matter of understanding. Don't do this at home xD.
        static void LogPowAnswer(int _base, int _exponent)
        {
            Console.WriteLine("{0}^{1} = {2}", _base, _exponent, Pow(_base, _exponent));
        }

        static int Pow(int _base, int _exponent)
        {
            if (_exponent == 1)
                return _base;
            else
                return _base * Pow(_base, _exponent - 1);

        }
    }
}
