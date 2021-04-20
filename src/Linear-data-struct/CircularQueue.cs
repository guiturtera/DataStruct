using System;
using System.Collections.Generic;
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
     
     ** CIRCULAR QUEUE:
     ** It has a fixed length, and is storage in an array.
     ** ENQUEUE (O(1))
     **     If the queue is full (Count == maxQueueSize), then will throw an Exception
     **     Inserts into the queue, at the topIndex position, increase Count in one and the topIndex + 1, if topIndex == topIndex, will return to 0.
     **         You can do this with the topIndex = (bottomIndex + 1) % maxQueueSize..
     ** DEQUEUE (O(1))
     **     Gets the data from the first inserted value.
     **     If the array is null, will throw an Exception
     **     Otherwhise, will return the value , change the Count -= 1, and the bottomIndex + 1, if bottomIndex == maxQueueSize, will return to 0.
     **         You can do this with the bottomIndex = (bottomIndex + 1) % maxQueueSize.
     ** COUNT 
     **     Returns the amount of data inside the Queue.
     
     ** TECHNICAL INFO:
     **     Contiguous storage -> YES
     **     Insert Method (Enqueue), in the worst case, is [O (1)]
     **     Search Method (Dequeue), in the worst case, is [O(1)]
     ** 
     
     ** PROS
     **     Fast for handling in specific problems.
     ** CONS
     **     Not flexible
     **     You can not search for a specific data.
     **     You can only insert in a fixed place.
     
     ** USAGE
     **     For example, when your are browsing in the internet, 
     **         the BACK and FORWARD button of your browser work as Stacks.
     */
    #endregion
    public class CircularQueue<T> : IQueue<T>
    {
        // THIS QUEUE IS WAY BETTER THAN THE STATIC ONE, THOUGH NOT BETTER THAN THE DYNAMIC.
        public int bottomIndex, topIndex;
        public int Count { get; private set; }
        public T[] data;
        public const int maxQueueSize = 100;

        public CircularQueue()
        {
            data = new T[maxQueueSize];
            Count = 0; topIndex = 0; bottomIndex = 0;
        }

        public T Dequeue()
        {
            T dataToReturn = data[bottomIndex];
            int aux = bottomIndex + 1;
            bottomIndex = aux % maxQueueSize;

            Count--;
            return dataToReturn;
        }

        public void Enqueue(T value)
        {
            if (Count == maxQueueSize) throw new Exception("Max queue size!");

            data[topIndex] = value;

            int aux = topIndex + 1;
            topIndex = aux % maxQueueSize;

            Count++;
        }

        public T Peek()
        {
            return data[Count - 1];
        }
    }
}
