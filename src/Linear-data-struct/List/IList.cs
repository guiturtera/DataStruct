using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_data_struct
{
    public interface IList<T>
    {
        int Count { get; }
        void Add(T value);
        void Clear();
        bool Remove(T data);
        void RemoveAt(int index);
        void Insert(T value, int index);
        T GetTop();
        T GetBottom();
        T GetAtt(int index);
    }
    
}
