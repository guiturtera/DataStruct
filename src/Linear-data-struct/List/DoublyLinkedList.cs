using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_data_struct
{
    public class DoublyLinkedList<T> : IList<T>
    {
        // THOSE METHODS ARE ONLY TO SHOW THAT ARE DIFFERENT MANNERS OF SHOWING DATA IN DOUBLY LINKED LISTS.
        // CON -> REQUIRE MORE MEMORY THAN THE SINGLY LINKED LIST
        // It could also be written as a CircularDoublyLinkedList, that, first node previous
        //      ref points to the last one, and it's next points to the first one.

        public string DisplayForward()
        {
            if (Count == 0) return "Null list";

            string storageString = "";
            TwoWayNode<T> node = firstNode;
            for (int i = 0; i < Count; i++) 
            {
                storageString += node.Value.ToString();
                node = node.NextNode;
            }

            return storageString;
        }
        public string DisplayBackward()
        {
            if (Count == 0) return "Null list";

            string storageString = "";
            TwoWayNode<T> node = lastNode;
            for (int i = Count - 1; i >= 0; i--)
            {
                storageString += node.Value.ToString();
                node = node.PreviousNode;
            }

            return storageString;
        }

        public int Count { get; private set; }
        private TwoWayNode<T> firstNode;
        private TwoWayNode<T> lastNode;

        public DoublyLinkedList()
        {
            Count = 0;
            firstNode = null;
            lastNode = null;
        }

        /// <summary>
        /// Will add at the last list's position.
        /// O(N). Will always do N, since is always the worst case.
        /// </summary>
        /// <param name="value">Value to be added at the end of the list</param>
        public void Add(T value)
        {
            Insert(value, Count);
        }

        /// <summary>
        /// Clear all list data. O(N)
        /// Here I am not making any data Dispose, though it should be done. I'm just deleting all refs, 
        ///     like disposing, but making them null. 
        /// </summary>
        public void Clear()
        {
            /*
            TwoWayNode<T> previousNode = firstNode;
            TwoWayNode<T> nextNode = firstNode.NextNode;

            // It should be disposed as this example, although it is not doing anything:
            for (int i = 0; i < Count - 1; i++)
            {
                previousNode = null;
                previousNode = nextNode;
                nextNode = nextNode.NextNode;
            }
            */

            // Only to simplify, I'll clear both first and top nodes, and make the Count 0. Garbage Collector will do the rest
            firstNode = null;
            lastNode = null;
            Count = 0;
        }

        /// <summary>
        /// Will return the data at a certain index.
        /// O(N)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetAt(int index)
        {
            return GetNodeFromIndex(index).Value;
        }
        public void Insert(T value, int index)
        {
            if (index < 0 || index > Count) throw new Exception("Index of the List not valid!");
            TwoWayNode<T> nodeToAdd = new TwoWayNode<T>(value, null, null);
            if (firstNode == null)
            {
                firstNode = nodeToAdd;
                lastNode = nodeToAdd;
            }
            else if (firstNode == lastNode)
            {
                lastNode = nodeToAdd;
                lastNode.PreviousNode = firstNode;
                firstNode.NextNode = lastNode;
            }
            else
            {
                if (index == 0)
                {
                    firstNode.PreviousNode = nodeToAdd;
                    firstNode.PreviousNode.NextNode = firstNode;
                    firstNode = firstNode.PreviousNode;
                }
                else if (index == Count)
                {
                    lastNode.NextNode = nodeToAdd;
                    lastNode.NextNode.PreviousNode = lastNode;
                    lastNode = lastNode.NextNode;
                }
                else
                {
                    TwoWayNode<T> previousNode = GetNodeFromIndex(index - 1);
                    TwoWayNode<T> nextNode = previousNode.NextNode;

                    nextNode.PreviousNode = nodeToAdd;
                    nodeToAdd.NextNode = nextNode;
                    nodeToAdd.PreviousNode = previousNode;
                    previousNode.NextNode = nodeToAdd;
                }
            }
            Count++;
        }

        public bool Remove(T value)
        {
            TwoWayNode<T> storageNode = firstNode;
            for (int i = 0; i < Count; i++)
            {
                if (storageNode.Value.Equals(value))
                {
                    RemoveAt(i);
                    return true;
                }

                storageNode = storageNode.NextNode;
            }
            return false;
        }

        /// <summary>
        /// Remove a data from the List at a specified index.
        /// </summary>
        /// <param name="index">Index delete the data.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new Exception("Invalid index!");

            if (Count == 1)
            {
                firstNode = null;
                lastNode = null;
            }
            else if (index == 0)
            {
                TwoWayNode<T> nodeToRemove = firstNode;
                firstNode = nodeToRemove.NextNode;
                nodeToRemove = null;
            }
            else if (index == Count - 1)
            {
                TwoWayNode<T> nodeToRemove = lastNode;
                lastNode = nodeToRemove.PreviousNode;
                nodeToRemove = null;
            }
            else if (index != 0)
            {
                TwoWayNode<T> nodeToRemove = GetNodeFromIndex(index);
                TwoWayNode<T> previousNode = nodeToRemove.PreviousNode;
                TwoWayNode<T> nextNode = nodeToRemove.NextNode;

                previousNode.NextNode = nextNode;
                nextNode.PreviousNode = previousNode;
                nodeToRemove = null;
            }
            Count--;
        }

        private TwoWayNode<T> GetNodeFromIndex(int index)
        {
            TwoWayNode<T> storageNode = firstNode;
            for (int i = 0; i < index; i++)
                storageNode = storageNode.NextNode;

            return storageNode;
        }

    }
}
