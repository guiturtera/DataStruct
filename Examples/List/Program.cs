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

            AssertDoublyList(5);

            Console.WriteLine();

            Console.ReadKey();
        }

        private static void AssertDoublyList(int assertsAmount)
        {
            for (int i = 0; i < assertsAmount; i++)
            {
                DoublyLinkedList<string> list = new DoublyLinkedList<string>();

                list.Add("a");
                list.RemoveAt(0);
                Assert("Null list", list.DisplayForward(), list.GetType().Name + "Remove at Count = 1");

                string expected = "0abcd6efghijklnopqrstuvwxy";

                string inverseExpected = expected.Reverse<char>().ToString();
                char[] aux = expected.ToCharArray();
                Array.Reverse(aux);
                inverseExpected = new string(aux);

                FillListForAssert(list);
                Assert(expected, list.DisplayForward(), list.GetType().Name + "DisplayForward()");
                Assert(inverseExpected, list.DisplayBackward(), list.GetType().Name + "DisplayBackward()");
                list.Clear();
            }
        }

        private static void AssertMultipleList(IList<string> list, int assertsAmount)
        {
            for (int i = 0; i < assertsAmount; i++)
            {
                AssertList(list);
                list.Clear();
            }
            Console.WriteLine();
        }

        static void AssertList(IList<string> list)
        {
            string expected = "0abcd6efghijklnopqrstuvwxy";

            FillListForAssert(list);
            string result = GetListResultForAssert(list);

            Assert(expected, result, list.GetType().Name);
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
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(caller + " - doesn't work!");
                builder.Append("Expected -> ");
                builder.AppendLine(expected);
                builder.Append("Result -> ");
                builder.AppendLine(result);
                WriteBackgroundColorLine(builder.ToString(), ConsoleColor.Red);
            }
        }
    }
}
