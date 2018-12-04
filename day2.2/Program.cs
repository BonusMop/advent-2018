using System;
using System.Collections.Generic;
using System.IO;

namespace day2._2
{
    class Program
    {
        static bool ExactlyOneDiff(string label1, string label2)
        {
            bool foundOneDiff = false;
            if (label1.Length != label2.Length) throw new ApplicationException(
                String.Format("Label lengths to not match for [{0}] and [{1}]", label1, label2));
            
            for (int i=0;i<label1.Length;i++) {
                if (label1[i] != label2[i]) {
                    if (foundOneDiff) return false; // Already had a difference
                    foundOneDiff = true;
                }
            }

            return foundOneDiff;
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            for (int i=0;i<lines.Length;i++) {
                for (int j=i+1;j<lines.Length;j++) {
                    if (ExactlyOneDiff(lines[i],lines[j])) {
                        Console.WriteLine("Maching boxes: ");
                        Console.WriteLine("One: {0}", lines[i]);
                        Console.WriteLine("Two: {0}", lines[j]);
                        break;
                    }
                }
            }
        }
    }
}
