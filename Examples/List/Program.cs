using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Linear_data_struct;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            AssertMultipleList(new StaticList<string>(), 10);
            AssertMultipleList(new LinkedList<string>(), 10);

            Console.WriteLine();

            Console.ReadKey();
        }

        private static void AssertMultipleList(IList<string> list, int assertsAmount)
        {
            for (int i = 0; i < assertsAmount; i++)
            {
                AssertList(list);
            }
            Console.WriteLine();
        }

        static void AssertList(IList<string> list)
        {
            string expected = "0abcd6efghijklnopqrstuvwxy";

            FillListForAssert(list);
            string result = GetListResultForAssert(list);

            Assert(expected, result, list.GetType().Name);
            list.Clear();
        }

        private static string GetListResultForAssert(IList<string> list)
        {
            string result = "";
            for (int i = 0; i < list.Count; i++)
                result += list.GetAt(i);

            return result;
        }

        private static void FillListForAssert(IList<string> list)
        {
            int firstLetter = 97;
            int finalLetter = firstLetter + 26;

            for (int i = firstLetter; i < finalLetter; i++)
                list.Add(((char)i).ToString());

            list.Insert("0", 0);
            list.Insert("2", 2);
            list.Insert("6", 6);
            list.Remove("z");
            list.Remove("m");
            list.RemoveAt(2);
        }

        static void WriteBackgroundColorLine(string text, ConsoleColor color) 
        {
            Console.BackgroundColor = color;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void Assert(string expected, string result, string caller) 
        {
            if (expected == result)
                WriteBackgroundColorLine(caller + " - works!", ConsoleColor.Green);
            else
                WriteBackgroundColorLine(caller + " - doesn't work!", ConsoleColor.Red);
        }
    }
}
