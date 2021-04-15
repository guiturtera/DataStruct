using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_data_struct.Interfaces
{
    /// <summary>
    /// // This interface will contain the main Stack Methods
    /// </summary>
    public interface IStack<T>
    {
        void Push(T value);
        T Pop();
        T Pick();
    }
}
