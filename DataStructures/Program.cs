using System;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new Buffer<double>();
            foreach (var item in buffer)
            {

            }
            ProcessInput(buffer);
            IEnumerable<int> listOfIntegers = new List<int>();
            listOfIntegers = buffer.AsEnumerableOfTOutput<int>();
            foreach (var item in listOfIntegers)
            {
                Console.WriteLine(item);
            }
            ProcessBuffer(buffer);

            Console.ReadKey();
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (!buffer.IsFull)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
    }
}
