using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_data_struct
{
    public class Node<T>
    {
        public Node(T value, Node<T> nextNode) 
        {
            this.NextNode = nextNode;
            this.Value = value;
        }
        public Node<T> NextNode { get; set; }
        public T Value { get; set; }
    }
}
