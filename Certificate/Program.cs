using Certificate.Chapter4.Examples.SerializationEzample;
using System;
using System.Collections.Generic;

namespace Certificate
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < 10; i++)
            {
                set.Add(i);
            }
            foreach (var s in set)
            {
            Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}
