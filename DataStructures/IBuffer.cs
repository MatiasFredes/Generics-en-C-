using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
   public interface IBuffer<T>: IEnumerable<T>
    {
        int Capacity { get; }
        bool IsEmpty { get; }
        bool IsFull { get; }
        IEnumerable<TOutput> AsEnumerableOfTOutput<TOutput>();

        T Read();
        void Write(T value);

    }
}
