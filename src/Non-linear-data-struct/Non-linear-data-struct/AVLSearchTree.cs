using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Non_linear_data_struct
{
    public class AVLSearchTree : BinarySearchTree
    {
        // Only Insertion Method added.
        Node RightRotate(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            // Perform rotation
            x.Right = y;
            y.Left = T2;

            // Update heights
            UpdateHeight(y);
            UpdateHeight(x);

            // Return new root
            return x;
        }

        // A utility function to left
        // rotate subtree rooted with x
        // See the diagram given above.
        Node LeftRotate(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            // Perform rotation
            y.Left = x;
            x.Right = T2;

            // Update heights
            UpdateHeight(x);
            UpdateHeight(y);

            // Return new root
            return y;
        }

        public override Node Insert(int value)
        {
            root = Insert(root, value);
            return root;
        }

        private Node Insert(Node currentNode, int value)
        {
            if (currentNode == null)
                return new Node(value, null, null, 0);

            // WILL MAKE HERE A VALIDATION FOR NOT REPEATED VALUES.
            // HERE THE PROGRAM IS RECUSIVE.
            if (value < currentNode.Value)
                currentNode.Left = Insert(currentNode.Left, value);
            else if (value > currentNode.Value)
                currentNode.Right = Insert(currentNode.Right, value);
            else
                throw new Exception("Same keys cannot be put in the same BST!");

            UpdateHeight(currentNode);
            int balance = GetBalance(currentNode);

            return CheckBalanceNode(currentNode, balance, value);
        }

        private Node CheckBalanceNode(Node currentNode, int balance, int value)
        {
            // Left Left Case
            if (balance > 1 && value < currentNode.Left.Value)
            {
                return RightRotate(currentNode);
            }
            // Right Right Case
            if (balance < -1 && value > currentNode.Right.Value)
            {
                return LeftRotate(currentNode);
            }
            // Left Right Case
            if (balance > 1 && value > currentNode.Left.Value)
            {
                currentNode.Left = LeftRotate(currentNode.Left);
                return RightRotate(currentNode);
            }
            // Right Left Case
            if (balance < -1 && value < currentNode.Right.Value)
            {
                currentNode.Right = RightRotate(currentNode.Right);
                return LeftRotate(currentNode);
            }

            return currentNode;
        }

        private void UpdateHeight(Node currentNode)
        {
            int left = Height(currentNode.Left);
            int right = Height(currentNode.Right);
            if (left > right)
                currentNode.Height = 1 + left;
            else
                currentNode.Height = 1 + right;
        }

        private int GetBalance(Node node)
        {
            return Height(node.Left) - Height(node.Right);
        }

        public override int Height(Node currentNode)
        {
            if (currentNode == null)
                return 0;

            return currentNode.Height;
        }

    }
}
