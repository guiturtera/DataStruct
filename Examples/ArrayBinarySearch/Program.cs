using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[] { 1, 3, 7, 9, 15, 17, 21, 65, 80, 99 };
            Console.WriteLine(DefaultBinarySearch(num, 15));
            Console.WriteLine(RecursiveBinarySearch(num, 15, 0, num.Length - 1));
            Console.ReadLine();
        }

        private static int RecursiveBinarySearch(int[] num, int numToSearch, int start, int end)
        {
            if (start > end)
                return -1;

            int middle = (start + end) / 2;
            if (num[middle] == numToSearch)
                return middle;
            else if (numToSearch > num[middle])
                return RecursiveBinarySearch(num, numToSearch, middle + 1, end);
            else
                return RecursiveBinarySearch(num, numToSearch, start, middle - 1);
        }

        private static int DefaultBinarySearch(int[] sortedArray, int numToSearch)
        {
            int start = 1, end = sortedArray.Length - 1, middle;

            do
            {
                middle = (start + end) / 2;
                if (numToSearch == sortedArray[middle])
                    return middle;
                else if (numToSearch > sortedArray[middle])
                    start = middle + 1;
                else
                    end = middle - 1;
            } while (start <= end);
            return -1;
        }
    }
}
