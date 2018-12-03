using System;
using System.IO;

namespace day1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            int total = 0;
            foreach (string line in lines)
            {
                int value = Int32.Parse(line);
                total += value;
                Console.WriteLine("Adding {0} to get the total {1}.", value, total);
            }
        }
    }
}
