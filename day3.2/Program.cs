using System;
using System.IO;
using System.Collections.Generic;

namespace day3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            List<Claim> claims = new List<Claim>();
            foreach (string line in lines)
                claims.Add(new Claim(line));

            for (int i=0;i<claims.Count;i++) {
                int nullCount=0;
                for (int j=0;j<claims.Count;j++) {
                    if (i==j) continue;
                    if (claims[i].OverlapsWith(claims[j]) == null) nullCount++;
                }
                if (nullCount == claims.Count - 1) Console.WriteLine("Claim {0} has no overlaps.", claims[i].Id);
            }
        }
    }
}
