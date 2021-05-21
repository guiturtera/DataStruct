using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] { 90, 81, 57, 26, 47, 29, 10 };
			QuickSort(data, 0, data.Length);
			Console.WriteLine("QuickSorted:");

			foreach (int num in data)
				Console.WriteLine(num);

			Console.ReadLine();
        }

        static void QuickSort(int[] data, int begin, int end) 
        {
			int i, j, pivo, aux;
			i = begin;
			j = end - 1;
			pivo = data[(begin + end) / 2];
			while (i <= j)
			{
				while (data[i] < pivo && i < end)
				{
					i++;
				}
				while (data[j] > pivo && j > begin)
				{
					j--;
				}
				if (i <= j)
				{
					aux = data[i];
					data[i] = data[j];
					data[j] = aux;
					i++;
					j--;
				}
			}
			if (j > begin)
				QuickSort(data, begin, j + 1);
			if (i < end)
				QuickSort(data, i, end);
		}
    }
}
