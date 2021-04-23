using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveMultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMultiplicationTable(9, 10);
            Console.WriteLine();
            ShowMultiplicationTable(4, 10);
            Console.ReadKey();
        }

        private static void ShowMultiplicationTable(int tableNumber, int finalNumber)
        {
            if (finalNumber > 0)
            {
                Console.WriteLine("{0} * {1} = {2}", tableNumber, finalNumber, tableNumber * finalNumber);
                ShowMultiplicationTable(tableNumber, finalNumber - 1);
            }
        }

        
    }
}
