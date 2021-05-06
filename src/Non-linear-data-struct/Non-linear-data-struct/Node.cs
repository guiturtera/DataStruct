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

        public Node(int value, Node leftNode, Node rightNode, int height)
        {
            this.Value = value;
            this.Left = leftNode;
            this.Right = rightNode;
            this.Height = height;
        }

        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }
        public int Height { get; set; }
    }
}
