using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_data_struct
{
    #region ABOUT THE STATICSTACK
    /*
     ** QUEUE BASICS:
     **     - A Queue works as FIFO (First in, first out).
     **     - In a Queue you can only pick (dequeue) the first inserted (enqueue) element.
     ** 
     
     ** STATIC QUEUE:
     ** It has a fixed length, and is storage in an array.
     ** ENQUEUE (O(1))
     **     Inserts into the queue, at the Count position and increase in one it's length.
     **     If the queue is full (Count == maxQueueSize), then will throw an Exception
     ** DEQUEUE (O(N))
     **     Gets the data from the first inserted value.
     **     If the array is null, will throw an Exception
     **     Otherwhise, will decrease one of the Queue Count(reference size index of the array), and
     **         will move all data back to 0.
     ** COUNT 
     **     Returns the amount of data inside the Queue.
     
     ** TECHNICAL INFO:
     **     Contiguous storage -> YES
     **     Insert Method (Enqueue), in the worst case, is [O (1)]
     **     Search Method (Dequeue), in the worst case, is [O(N)]
     ** 
     
     ** PROS
     **     A normal queue is fast for handling, though this one is not the recommended one to be used.
     ** CONS
     **     Not flexible
     **     You can not search for a specific data.
     **     You can only insert in a fixed place.
     
     ** USAGE
     **     For example, when your are browsing in the internet, 
     **         the BACK and FORWARD button of your browser work as Stacks.
     */
    #endregion
    public class StaticQueue<T> : IQueue<T>
    {
        // THIS IS THE WORST POSSIBLE LIST, SINCE DEQUEUE METHOD IS NOT O(1)
        public int Count { get; private set; }
        public T[] data;
        public const int maxQueueSize = 100;

        public StaticQueue()
        {
            data = new T[maxQueueSize];
            Count = 0;
        }

        public T Dequeue()
        {
            T dataToReturn = data[0];
            for (int i = 0; i < Count; i++)
                data[i] = data[i + 1];
            Count--;
            return dataToReturn;
        }

        public void Enqueue(T value)
        {
            if (Count == maxQueueSize) throw new Exception("Max queue size!");
            data[Count] = value;
            Count++;
        }

        public T Peek()
        {
            return data[Count - 1];
        }
    }
}
