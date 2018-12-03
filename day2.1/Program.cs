using System;
using System.Collections.Generic;
using System.IO;

namespace day2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            int twos = 0;
            int threes = 0;

            foreach (string line in lines)
            {
                Dictionary<char,int> letterCount = new Dictionary<char, int>();
                foreach (char c in line)
                {
                    if (letterCount.ContainsKey(c)) {
                        letterCount[c]++;
                    } else {
                        letterCount.Add(c,1);
                    }
                }
                bool hasTwo = false;
                bool hasThree = false;
                foreach (char k in letterCount.Keys)
                {
                    if (letterCount[k]==2) hasTwo = true;
                    if (letterCount[k]==3) hasThree = true;
                }
                if (hasTwo) twos++;
                if (hasThree) threes++;
            }

            Console.WriteLine("boxes with 2: {0}", twos);
            Console.WriteLine("boxes with 3: {0}", threes);
            Console.WriteLine("checksum: {0}", twos*threes);
        }
    }
}
