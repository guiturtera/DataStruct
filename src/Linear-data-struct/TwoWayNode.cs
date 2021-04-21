using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_data_struct
{
    public class TwoWayNode<T>
    {
        public TwoWayNode(T value, TwoWayNode<T> previousNode, TwoWayNode<T> nextNode)
        {
            this.NextNode = nextNode;
            this.PreviousNode = previousNode;
            this.Value = value;
        }

        public TwoWayNode<T> NextNode { get; set; }
        public TwoWayNode<T> PreviousNode { get; set; }
        public T Value { get; set; }
    }
}
