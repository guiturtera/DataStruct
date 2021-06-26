using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Test_Non-linear-data-struct")]

namespace Non_linear_data_struct
{

    public enum HeapType
    {
        Max,
        Min
    }
    // Implementations:
    // - A more efficient way to do priority queues
    // - Used in HeapSort (widely used sort algorithm)
    // - Used in efficient graph algorithms

    // This one will be represented as array of integers (using c# list to help with that, since it's a resizable array)
    // I'll use Min Heap here, because Max Heap has the same concept, but with the highest value at the root
    public class BinaryHeap
    {
        // data[0] is the root
        // data[(2 * i) + 1] -> left node
        // data[(2 * i) + 2] -> right node
        // data[(i - 1) / 2] -> parent node

        Func<int, int, bool> comparison;
        internal List<int> data;
        public int Count { get { return data.Count; } }

        public BinaryHeap(HeapType type)
        {
            data = new List<int>();
            if (type == HeapType.Min)
                comparison = new Func<int, int, bool>((value, parentIndex) => { return value < parentIndex; });
            else
                comparison = new Func<int, int, bool>((value, parentIndex) => { return value > parentIndex; });
        }

        internal void SwitchValues(int index1, int index2)
        {
            int aux = data[index1];
            data[index1] = data[index2];
            data[index2] = aux;
        }

        public BinaryHeap Insert(int value)
        {
            // Add value in one of the leaf nodes
            data.Add(value);

            if (data.Count > 1)
            {
                // Will always insert into the last index
                int currentIndex = data.Count - 1;
                int parentIndex = (currentIndex - 1) / 2;
                int parentValue = data[parentIndex];
                // Will pass through parent nodes and Switch values until the value node is in the correct heap position
                while (currentIndex != 0 && comparison(value, parentValue))
                {
                    SwitchValues(currentIndex, parentIndex);
                    currentIndex = parentIndex;
                    parentIndex = (currentIndex - 1) / 2;
                    parentValue = data[parentIndex];
                }
            }
            return this;
        }

        // Delete is always done from the root.
        public BinaryHeap Delete()
        {
            // Switches the root with the last node
            int parentIndex = 0, leftIndex = 1, rightIndex = 2;
            
            SwitchValues(parentIndex, data.Count - 1);
            // Deletes the last node (previously the root)
            data.RemoveAt(data.Count - 1);

            if (data.Count > 1)
            {
                while(leftIndex < data.Count - 1)
                {
                    if (comparison(data[parentIndex], data[leftIndex]) && comparison(data[parentIndex], data[rightIndex]))
                        break;

                    if (comparison(data[leftIndex], data[rightIndex]))
                    {
                        SwitchValues(parentIndex, leftIndex);
                        parentIndex = leftIndex;
                    }
                    else
                    {
                        SwitchValues(parentIndex, rightIndex);
                        parentIndex = rightIndex;
                    }

                    leftIndex = (2 * parentIndex) + 1;
                    rightIndex = leftIndex + 1;
                }
            }

            return this;
        }
    }
}
