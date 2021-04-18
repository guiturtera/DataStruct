using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_data_struct
{
    /*
    ** STACK BASICS:
    **     - A Stack works as LIFO (Last in, first out).
    **     - In a Stack you can only pick (pop) the last inserted (push) element.
    ** 

    ** Dynamic STACK:
    ** Doesn't necessarily have a fixed length.
    ** PUSH 
    **     Update the TopNode. 
    **          If the first value, will store the nextnode as null.
    **          Else update the first node and fill the next with the previous reference.
    ** POP 
    **     Gets the data from the last inserted.
    **     If the array was null, will throw an Exception
    **     Otherwhise, will return topNode.Value and update the topNode for the topNode.NextNode. 
    ** COUNT 
    **     Returns the amount of data inside the Stack.

    ** TECHNICAL INFO:
    **     Contiguous storage -> NO
    **     Insert Method (Push), in the worst case, is [O (1)]
    **     Search Method (Pop), in the worst case, is [O(1)]
    ** 

    ** PROS
    **     Fast for handling
    ** CONS
    **     Not flexible
    **     You can not search for a specific data.
    **     You can only insert in a fixed place.

    ** USAGE
    **     For example, when your are browsing in the internet, 
    **         the BACK and FORWARD button of your browser work as Stacks.
    */
    public class DynamicStack<T> : IStack<T>
    {
        public int Count { get; private set; }

        private Node<T> topNode;
        private int maxStackSize;
        public DynamicStack() 
        {
            Count = 0;
            this.maxStackSize = 200;
            this.topNode = null;
        }

        public T Peek()
        {
            return topNode.Value;
        }

        public T Pop()
        {
            if (Count == 0) throw new Exception("The stack don't have any element!");

            Node<T> aux = topNode;
            if (aux.NextNode != null)
                topNode = aux.NextNode;
            else
                topNode = null;
            Count--;
            return aux.Value;
        }

        public void Push(T value)
        {
            if (Count == maxStackSize) throw new StackOverflowException("StackOverflow!");

            if (Count == 0)
                topNode = new Node<T>(value, null);
            else
            {
                Node<T> nextNode = topNode.NextNode;
                topNode = new Node<T>(value, topNode);
            }
            Count++;
        }
    }
}
