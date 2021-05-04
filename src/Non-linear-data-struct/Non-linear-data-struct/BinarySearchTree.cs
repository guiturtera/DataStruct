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
    // It will be done only to simplify, with INTEGER.
    public class BinarySearchTree
    {
        internal Node root;
        // IT WILL ALWAYS INSERT AT A LEAF NODE.
        // It's worst case is O(height).
        // Obs: Height is the maximum path length existing in a tree.
        public virtual void Insert(int value)
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

        // Search for a node and returns if the value exists.
        // Same time complexity as the Insert, since also searches for a node
        public bool Contains(int value) 
        {
            return Search(value).Exists;
        }

        // THIS METHOD WILL DELETE A VALUE FROM THE TREE
        // IT HAS O(logN) in average, and O(N) in the worst (Only one path)
        public bool Delete(int value) 
        {
            SearchResponse response = Search(value);
            Node parent = response.FoundParent;
            Node found = response.Found;

            if (response.Exists)
            {
                // LEAF NODE
                if (found.Left == null && found.Right == null)
                {
                    // IF IT'S THE ROOT NODE
                    if (parent == null)
                        root = null;
                    else
                        DeleteParentRef(parent, found);
                }
                // NODE HAS TWO CHILDREN
                else if (found.Left != null && found.Right != null)
                {
                    Node replaceNode = found.Right;
                    Node rightLowerNode = FindLowerNode(found.Right);
                    rightLowerNode.Left = found.Left;
                    ReplaceNode(found, replaceNode);
                }
                // NODE HAS ONE LEFT CHILD
                else if (found.Left != null)
                {
                    ReplaceNode(found, found.Left);
                }
                // NODE HAS ONE RIGHT CHILD
                else
                {
                    ReplaceNode(found, found.Right);
                }
            }

            return response.Exists;
        }

        public int Height()
        {
            return Height(root);
        }

        private int Height(Node currentNode)
        {
            int heightLeft, heightRight;
            if (currentNode == null)
                return 0;
            else
            {
                heightLeft = Height(currentNode.Left);
                heightRight = Height(currentNode.Right);
                if (heightLeft > heightRight)
                    return heightLeft + 1;
                else
                    return heightRight + 1;
            }
        }

        // ROOT - LEFT - RIGHT
        public List<int> PreOrderTransversal()
        {
            List<int> list = new List<int>();
            PreOrderTransversal(list, root);
            return list;
        }

        private void PreOrderTransversal(List<int> list, Node currentNode) 
        {
            if (currentNode != null)
            {
                list.Add(currentNode.Value);
                PreOrderTransversal(list, currentNode.Left);
                PreOrderTransversal(list, currentNode.Right);
            }
        }

        // LEFT - ROOT - RIGHT
        public List<int> InOrderTransversal()
        {
            List<int> list = new List<int>();
            InOrderTransversal(list, root);
            return list;
        }

        private void InOrderTransversal(List<int> list, Node currentNode)
        {
            if (currentNode != null)
            {
                InOrderTransversal(list, currentNode.Left);
                list.Add(currentNode.Value);
                InOrderTransversal(list, currentNode.Right); 
            }
        }

        // LEFT - RIGHT - ROOT 
        public List<int> PostOrderTransversal()
        {
            List<int> list = new List<int>();
            PostOrderTransversal(list, root);
            return list;
        }

        private void PostOrderTransversal(List<int> list, Node currentNode)
        {
            if (currentNode != null)
            {
                PostOrderTransversal(list, currentNode.Left);
                PostOrderTransversal(list, currentNode.Right);
                list.Add(currentNode.Value);
            }
        }

        private void ReplaceNode(Node currentNode, Node newNode) 
        {
            currentNode.Left = newNode.Left;
            currentNode.Right = newNode.Right;
            currentNode.Value = newNode.Value;
        }

        public Node FindLowerNode()
        {
            return FindLowerNode(root);
        }

        private Node FindLowerNode(Node root)
        {
            if (root.Left == null)
                return root;

            return FindLowerNode(root.Left);
        }

        public Node FindHigherNode()
        {
            return FindHigherNode(root);
        }

        private Node FindHigherNode(Node root)
        {
            if (root.Right == null)
                return root;

            return FindHigherNode(root.Right);
        }

        private void DeleteParentRef(Node parent, Node found)
        {
            if (found.Value < parent.Value)
                parent.Left = null;
            else
                parent.Right = null;
        }

        private SearchResponse Search(int value) 
        {
            Node parentNode = null;
            Node currentNode = root;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                    return new SearchResponse(true, currentNode, parentNode);

                parentNode = currentNode;
                if (value > currentNode.Value)
                    currentNode = currentNode.Right;
                else
                    currentNode = currentNode.Left;
            }

            return new SearchResponse(false, null, null);
        }
    }

    internal class SearchResponse 
    {
        public Node FoundParent { get; set; }
        public Node Found { get; set; }
        public bool Exists { get; set; }

        public SearchResponse(bool exists, Node found, Node foundParent) 
        {
            this.Exists = exists;
            this.Found = found;
            this.FoundParent = foundParent;
        }
    }
}
