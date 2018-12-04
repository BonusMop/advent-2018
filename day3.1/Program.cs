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

            bool[,] fabric = new bool[1000,1000];

            for (int i=0;i<claims.Count-1;i++) {
                for (int j=i+1;j<claims.Count;j++) {
                    Claim overlap = claims[i].OverlapsWith(claims[j]);
                    if (overlap != null) {
                        Console.WriteLine("From {4} and {5}: {0},{1}-{2},{3}", overlap.LeftMargin, overlap.TopMargin, overlap.LeftMargin+overlap.Width, overlap.TopMargin+overlap.Height, claims[i].Id, claims[j].Id);
                                
                        for (int x=overlap.LeftMargin;x<overlap.LeftMargin+overlap.Width;x++) {
                            for (int y=overlap.TopMargin;y<overlap.TopMargin+overlap.Height;y++) {
                                fabric[x,y] = true;
                            }
                        }
                    }
                }
            }

            int totalOverlaps = 0;
            for (int i=0;i<1000;i++)
                for (int j=0;j<1000;j++)
                    if (fabric[i,j]) totalOverlaps++;

            Console.Write("Total overlaps: {0}", totalOverlaps);
        }
    }
}
