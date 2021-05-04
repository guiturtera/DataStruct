using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Non_linear_data_struct
{
    public class AVLSearchTree : BinarySearchTree
    {
        private bool hasInserted;
        public override void Insert(int value)
        {
            if (root == null)
            {
                root = new Node(value, null, null, 0);
                return;
            }
            hasInserted = false;
            Insert(value, root);
        }

        private Node Insert(int value, Node current)
        {
            if (current == null)
            {
                current = new Node(value, null, null, 0);
                return current;
            }

            // WILL GO THROUGH THE TREE UNTILL FOUND NODE IS NULL
            if (value < current.Value)
            {
                current.Left = Insert(value, current.Left);
                if (!hasInserted) 
                {
                    // SWITCH FOR BALANCED CASES
                    switch (current.Balance)
                    {
                        // Right heavy, will turn int balanced.
                        case -1:
                            current.Balance = 0;
                            hasInserted = true;
                            break;
                        // Tree balanced will turn into LeftHeavy.
                        case 0:
                            current.Balance = 1;
                            break;
                        // Case LeftHeavy, will do:
                        case 1:
                            Node child = current.Left;
                            if (child.Balance == 1)
                            {
                                // Will do LL rotation (Left to Left)
                                current.Left = child.Right;
                                child.Right = current;
                                current.Balance = 0;
                                child.Balance = 0;
                                current = child;
                            }
                            else
                            {
                                // Will do LR rotation (Left to right)
                                Node aux = child.Right;
                                child.Right = aux.Left;
                                aux.Left = child;
                                current.Left = aux.Right;
                                aux.Right = current;
                                if (aux.Balance == 1)
                                    current.Balance = -1;
                                else
                                    current.Balance = 0;
                                if (aux.Balance == -1)
                                    child.Balance = 1;
                                else
                                    child.Balance = 0;
                                aux.Balance = 0;
                                current = aux;
                            }
                            break;
                    }
                    hasInserted = true;
                }
            }
            else if (value > current.Value)
            {
                current.Right = Insert(value, current.Right);

                if (!hasInserted)
                {
                    switch (current.Balance)
                    {
                        // Left heavy, will turn int balanced.
                        case -1:
                            current.Balance = 0;
                            hasInserted = true;
                            break;
                        // Tree balanced will turn into RightHeavy.
                        case 0:
                            current.Balance = 1;
                            break;
                        // Case RightHeavy, will do:
                        case 1:
                            Node child = current.Right;
                            if (child.Balance == 1)
                            {
                                // Will do LL rotation (Left to Left)
                                current.Right = child.Left;
                                child.Left = current;
                                current.Balance = 0;
                                child.Balance = 0;
                                current = child;
                            }
                            else
                            {
                                // Will do LR rotation (Left to right)
                                Node aux = child.Left;
                                child.Left = aux.Right;
                                aux.Right = child;
                                current.Right = aux.Left;
                                aux.Left = current;
                                if (aux.Balance == -1)
                                    current.Balance = 1;
                                else
                                    current.Balance = 0;
                                if (aux.Balance == 1)
                                    child.Balance = 1;
                                else
                                    child.Balance = 0;
                                aux.Balance = 0;
                                current = aux;
                            }
                            break;
                    }
                    hasInserted = true;
                }
            }
            return current;
        }
    }
}
