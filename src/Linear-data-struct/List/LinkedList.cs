using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_data_struct
{
    public class LinkedList<T> : IList<T>
    {
        // This example uses the conceptual SinglyLinkedList, which is not so efficient.
        // You could add Sentinel Nodes, for fast handling data.
        public int Count { get; private set; }
        private Node<T> firstNode;

        public LinkedList()
        {
            Count = 0;
            firstNode = null;
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
        /// </summary>
        public void Clear()
        {
            Node<T> previousNode = firstNode;
            Node<T> nextNode = firstNode.NextNode;

            for (int i = 0; i < Count - 1; i++)
            {
                previousNode = null;
                previousNode = nextNode;
                nextNode = nextNode.NextNode;
            }
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
            if (firstNode == null)
            {
                firstNode = new Node<T>(value, null);
            }
            else
            {
                Node<T> nodeToAdd = new Node<T>(value, null);
                if (index != 0)
                {
                    Node<T> previousNode = GetNodeFromIndex(index - 1);
                    Node<T> nextNode = previousNode.NextNode;

                    nodeToAdd.NextNode = nextNode;
                    previousNode.NextNode = nodeToAdd;
                }
                else
                {
                    nodeToAdd.NextNode = firstNode;
                    firstNode = nodeToAdd;
                }    
            }
            Count++;
        }

        public bool Remove(T value)
        {
            Node<T> storageNode = firstNode;
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
        /// Remoev a data from the List at a specified index.
        /// </summary>
        /// <param name="index">Index delete the data.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count) throw new Exception("Invalid index!");
            
            if (index != 0)
            {
                Node<T> previousNode = GetNodeFromIndex(index - 1); 
                Node<T> nodeToRemove = previousNode.NextNode;
                Node<T> nextNode = nodeToRemove.NextNode;

                previousNode.NextNode = nextNode;
                nodeToRemove = null;
            }
            else
            {
                Node<T> nodeToRemove = firstNode;
                firstNode = nodeToRemove.NextNode;
                nodeToRemove = null;
            }
            Count--;
        }

        private Node<T> GetNodeFromIndex(int index)
        {
            Node<T> storageNode = firstNode;
            for (int i = 0; i < index; i++)
                storageNode = storageNode.NextNode;

            return storageNode;
        }
    }
}
