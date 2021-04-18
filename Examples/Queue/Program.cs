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
            //IQueue<string> queue = new StaticQueue<string>();
            IQueue<string> queue = new StaticQueue<string>();
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

            Console.ReadKey();
        }
    }
}
