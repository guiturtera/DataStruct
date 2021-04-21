using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_data_struct
{
    public class StaticList<T> : IList<T>
    {
        public int Count { get; private set; }
        private T[] data;
        private int length;
        private const int INITIAL_CONT = 10;
        public StaticList()
        {
            length = INITIAL_CONT; // Initial length will be 10.
            data = new T[length]; 

            Count = 0;
        }

        /// <summary>
        /// Will add at a new List position, at it's top.
        /// </summary>
        /// <param name="value">The value to be added at the List</param>
        public void Add(T value)
        {
            Insert(value, Count);
        }

        /// <summary>
        /// Will clear the data array.
        /// Will dispose the array and create a new one with the initial length.
        /// O(N)
        /// PS: Garbage collector is doing the dirty job
        /// </summary>
        public void Clear()
        {
            length = INITIAL_CONT;
            data = new T[length];
            Count = 0;
        }

        /// <summary>
        /// Although, here you can make it O(1), since you have the array.
        /// </summary>
        /// <param name="index">Index to get the value</param>
        /// <returns>Returns the value at the specified index</returns>
        public T GetAt(int index)
        {
            if (index < 0 || index >= Count) throw new Exception("Invalid term.");
            return data[index];
        }
        
        /// <summary>
        /// Here you can insert at the bottom and at the Count position(Top)
        /// O(N). Will be N when added at the bottom.
        /// </summary>
        /// <param name="value">Value to be added</param>
        /// <param name="index">Index to add the value</param>
        public void Insert(T value, int index)
        {
            if (index < 0 || index > Count) throw new Exception("Index not valid!");

            if (Count == length - 1)
            {
                length *= length;
                Array.Resize(ref data, length);
            }
            if (Count == 0)
                data[Count] = value;
            else
            {
                for(int i = Count; i >= index; i--)
                {
                    data[i + 1] = data[i];
                }
                data[index] = value;
            }

            Count++;

        }

        /// <summary>
        /// O(N). Searches for a value. if found, will delete from the list and return true. 
        /// Otherwise, will return false
        /// </summary>
        /// <param name="value">Value to be deleted from the list</param>
        /// <returns></returns>
        public bool Remove(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (data[i].Equals(value))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Removes at a certain index.
        /// If index is invalid, will throw an Exception.
        /// O(N).
        /// </summary>
        /// <param name="index">Index to the delete the item.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count) throw new Exception("Index not valid!");

            for (int i = index; i < Count; i++)
            {
                data[i] = data[i + 1];
            }
            Count--;
        }
    }
}
