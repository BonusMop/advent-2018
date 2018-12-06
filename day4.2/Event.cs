using System;
using System.Text.RegularExpressions;

namespace day4._2
{
    public enum EventType {
        Start,
        Sleep,
        Wake
    }

    public class Event
    {
        public DateTime Time { get; private set; }
        public string Text { get; private set; }
        public EventType Type { get; private set; }
        public int GuardId { get; private set; }


        public Event(string description)
        {
            Match match = Regex.Match(description, @"\[(\d\d\d\d-\d\d-\d\d \d\d:\d\d)\] (.+)");

            if (match.Groups.Count != 3) 
                throw new ApplicationException(String.Format("Unexpected event description format: {0}", description));
            this.Time = DateTime.Parse(match.Groups[1].Value);
            this.Text = match.Groups[2].Value;

            
            if (this.Text == "falls asleep") {
                this.Type = EventType.Sleep;
            } else if (this.Text == "wakes up") {
                this.Type = EventType.Wake;
            } else {
                this.Type = EventType.Start;
                Match guardMatch = Regex.Match(this.Text, @"Guard #(\d+) begins shift");
                if (guardMatch.Groups.Count != 2) 
                    throw new ApplicationException(String.Format("Unexpected event description format: {0}", description));
                this.GuardId = Int32.Parse(guardMatch.Groups[1].Value);
            }

        }
    }
}
