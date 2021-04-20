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
     
     ** DYNAMIC QUEUE:
     ** It doesn't necessarily have a fixed length.
     ** ENQUEUE (O(1))
     **     Will point the top node to a new one.
     ** DEQUEUE (O(1))
     **     Will return the bottom node and point it to the next one.
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
    public class DynamicQueue<T> : IQueue<T>
    {
        // You don't necessarily need to set a max lenght.
        public int Count { get; set; }
        Node<T> bottomNode, topNode;
        
        public DynamicQueue()
        {
            Count = 0;
            this.bottomNode = null;
            this.topNode = null;
        }

        public T Dequeue()
        {
            if (Count == 0) throw new Exception("Empty queue!");
            Node<T> nodeToReturn = bottomNode;

            bottomNode = bottomNode.NextNode;

            Count--;
            return nodeToReturn.Value;
        }

        public void Enqueue(T value)
        {
            if (Count == 0)
            {
                bottomNode = new Node<T>(value, null);
            }
            else if (Count == 1)
            {
                topNode = new Node<T>(value, null);
                bottomNode.NextNode = topNode;
            }
            else
            {
                topNode.NextNode = new Node<T>(value, null);
                topNode = topNode.NextNode;
            }
            Count++;
        }

        public T Peek()
        {
            if (Count == 0) throw new Exception("Empty queue!");
            return this.bottomNode.Value;
        }
    }
}
