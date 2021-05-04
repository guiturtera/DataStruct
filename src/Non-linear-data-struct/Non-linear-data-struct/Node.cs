using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Non_linear_data_struct
{
    public class Node
    {
        public Node(int value, Node leftNode, Node rightNode) 
        {
            this.Value = value;
            this.Left = leftNode;
            this.Right = rightNode;
        }

        public Node(int value, Node leftNode, Node rightNode, int balance)
        {
            this.Value = value;
            this.Left = leftNode;
            this.Right = rightNode;
            this.Balance = balance;
        }

        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }
        public int Balance { get; set; }
    }
}
