using System;
using Linear_data_struct.Interfaces;

namespace Linear_data_struct
{
    #region ABOUT THE STATICSTACK
    /*
     ** STACK BASICS:
     **     - A Stack works as LIFO (Last in, first out).
     **     - In a Stack you can only pick (pop) the last inserted (push) element.
     ** 
     
     ** STATIC STACK:
     ** It has a fixed length, and is storage in an array.
     ** PUSH 
     **     Inserts into the array, with it's length as index.
     **     If the stack is full (Count == MaxStackSize), then will throw an Exception
     ** POP 
     **     Gets the data from the last inserted.
     **     If the array was null, will throw an Exception
     **     Otherwhise, will decrease one of the Stack Count(reference size index of the array)
     ** COUNT 
     **     Returns the amount of data inside the Stack.
     
     ** TECHNICAL INFO:
     **     Contiguous storage -> YES
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
    #endregion
    public class StaticStack<T> : IStack<T>
    {
        public int Count { get; private set; }
        private int maxStackSize = 200;
        private T[] data;

        public StaticStack()
        {
            this.maxStackSize = 200;
            this.data = new T[maxStackSize];
            Count = 0;
        }
        public void Push(T value)
        {
            if (Count == 200) throw new StackOverflowException("StackOverflow!");

            this.data[Count] = value;
            this.Count++;
        }

        public T Pop()
        {
            T aux = this.data[Count - 1];
            this.data[Count - 1] = default(T);
            Count--;
            return aux;
        }

        public T Pick()
        {
            return this.data[Count - 1];
        }
    }
    
}
