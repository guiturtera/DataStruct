using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecusiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            LogFactorial(2);
            LogFactorial(4);
            LogFactorial(6);
            LogFactorial(8);
            LogFactorial(10);

            Console.ReadKey();
        }

        public static void LogFactorial(int number) 
        {
            Console.WriteLine("{0}! -> {1}", number, Factorial(number));
            Console.WriteLine();
        }

        public static int Factorial(int number)
        {
            if (number > 0)
                return number * Factorial(number - 1);
            else
                return 1;
        }
    }
}
