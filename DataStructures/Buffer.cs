using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Buffer<T> : IBuffer<T>
    {
        private Queue<T> _circularBuffer;
        public Buffer(int capacity = 5)
        {
            this._circularBuffer = new Queue<T>();
            this.Capacity = 5;
        }
        
        public int Capacity { get; }

        public bool IsEmpty { get { return this._circularBuffer.Count == 0; } }

        public bool IsFull { get { return this._circularBuffer.Count == this.Capacity; } }

        public IEnumerable<TOutput> AsEnumerableOfTOutput<TOutput>()
        {
            IList<TOutput> listOfTOutput = new List<TOutput>();
            var converter = TypeDescriptor.GetConverter(typeof(T));

            foreach(T item in this._circularBuffer)
            {
                var result = converter.ConvertTo(item, typeof(TOutput));
                listOfTOutput.Add((TOutput)result);
            }
            return listOfTOutput;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this._circularBuffer.GetEnumerator();
        }

        public T Read()
        {
           return this._circularBuffer.Dequeue();
        }

        public void Write(T value)
        {
            if (IsFull)
                this._circularBuffer.Dequeue();

            this._circularBuffer.Enqueue(value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
