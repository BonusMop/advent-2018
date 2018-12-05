using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            List<Event> events = new List<Event>();
            foreach(string line in lines) {
                events.Add(new Event(line));
            }

            Dictionary<int,Guard> guards = new Dictionary<int, Guard>();
            Guard currentGuard = null;
            foreach (Event guardEvent in events.OrderBy(e => e.Time))
            {
                if (guardEvent.Type == EventType.Start) {
                    if (guards.ContainsKey(guardEvent.GuardId))
                    {
                        currentGuard = guards[guardEvent.GuardId];
                    } else {
                        currentGuard = new Guard(guardEvent.GuardId);
                        guards.Add(guardEvent.GuardId, currentGuard);
                    }
                } else if (guardEvent.Type == EventType.Sleep) {
                    currentGuard.Sleep(guardEvent.Time);
                } else if (guardEvent.Type == EventType.Wake) {
                    currentGuard.Wake(guardEvent.Time);
                } else {
                    throw new ApplicationException(String.Format("Unexpected event type {0}",guardEvent.Type.ToString()));
                }
                Console.WriteLine("{0}: {1}", guardEvent.Time, guardEvent.Text);
            }

            Guard sleepiestGuard = guards.Values.OrderByDescending(g => g.MinutesSlept).First();
            
            Console.WriteLine();
            Console.WriteLine("Results: ");
        
            Console.WriteLine(" Sleepiest Guard is #{0}", sleepiestGuard.Id);
            Console.WriteLine(" Guard slept for {0} minutes total.", sleepiestGuard.MinutesSlept);
            Console.WriteLine(" Guard was asleep most often at {0} minutes after the hour", sleepiestGuard.GetSleepiestMinute());
        }
    }
}
