using System;
using System.Collections.Generic;
using System.IO;


namespace day1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            int total = 0;
            bool done = false;
            Dictionary<int,bool> results = new Dictionary<int, bool>();

            while(!done)
            {
                foreach (string line in lines)
                {
                    int value = Int32.Parse(line);
                    total += value;
                    Console.WriteLine("Adding {0} to get the total {1}.", value, total);
                    if (results.ContainsKey(total))
                    {
                        Console.WriteLine("Found repeated frequency {0}", total);
                        done = true;
                        break;
                    }
                    results.Add(total,true);
                }
            }
        }
    }
}
