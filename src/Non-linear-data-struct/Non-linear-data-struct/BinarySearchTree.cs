using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Test_Non-linear-data-struct")]

namespace Non_linear_data_struct
{
    // This SearchTree is only an Concept Example. 
    // When searching for some data, we usually use Self-Balanced trees, such as AVL ones.
    // If they are not in the project yet, it'll be in a few days
    // It will be done only to simplify, with INTEGER.
    public class BinarySearchTree
    {
        internal Node root;
        // IT WILL ALWAYS INSERT AT A LEAF NODE.
        // It's worst case is O(height).
        // Obs: Height is the maximum path length existing in a tree.
        public void Insert(int value)
        {
            Node nodeToCreate = new Node(value, null, null);
            if (root == null)
            {
                root = nodeToCreate;
            }
            else
            {
                Node parentCurrentNode = null;
                Node currentNode = root;
                while (currentNode != null)
                {
                    parentCurrentNode = currentNode;
                    if (value < currentNode.Value)
                        currentNode = currentNode.Left;
                    else
                        currentNode = currentNode.Right;
                }

                if (value < parentCurrentNode.Value)
                    parentCurrentNode.Left = nodeToCreate;
                else
                    parentCurrentNode.Right = nodeToCreate;
            }
        }
    }
}
