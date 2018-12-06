using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day4._2
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

            int maxMinuteValue = 0;
            int maxMinuteTime = 0;
            int maxGuardId = 0;
            foreach (Guard g in guards.Values) {
                for (int i=0;i<60;i++) {
                    if (g.SleepRecord[i] > maxMinuteValue) {
                        maxMinuteValue = g.SleepRecord[i];
                        maxMinuteTime = i;
                        maxGuardId = g.Id;
                    }
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("Results: ");
            Console.WriteLine(" Sleepiest minute for any guard is {0} with {1} matching events", maxMinuteTime, maxMinuteValue);
            Console.WriteLine(" The guard sleeping then most often is #{0}", maxGuardId);
            Console.WriteLine(" Guard x Minute = {0}", maxGuardId*maxMinuteTime);
        }
    }
}
