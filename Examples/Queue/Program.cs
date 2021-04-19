using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linear_data_struct;

namespace Queue
{
    class Program
    {
        // Simulating an unit test
        static void Main(string[] args)
        {
            AssertQueue(new StaticQueue<string>());

            IQueue<string> circularQueue = new CircularQueue<string>();
            Console.WriteLine(Environment.NewLine + "8 Tests for CircularQueue: ");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("{0}°", i + 1);
                AssertQueue(circularQueue);
            }

            Console.WriteLine();

            Console.ReadKey();
        }

        private static void AssertQueue(IQueue<string> queue)
        {
            const int codeOfLetterA = 97;
            string assertText = "";

            for (int i = 0; i < 26; i++)
                assertText += Convert.ToChar(codeOfLetterA + i);

            for (int i = 0; i < 26; i++)
                queue.Enqueue(Convert.ToChar(codeOfLetterA + i).ToString());

            int queueLength = queue.Count;
            string resultText = "";
            for (int i = 0; i < queueLength; i++)
                resultText += queue.Dequeue();

            if (resultText == assertText)
                Console.WriteLine("Queue works!!");
            else
                Console.WriteLine("Queue doesn't work!");
        }
    }
}
