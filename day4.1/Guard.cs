using System;

namespace day4._1
{
    public class Guard
    {
        public int MinutesSlept { get; private set; }
        public int[] SleepRecord { get; private set; }
        public int Id { get; private set; }

        public int GetSleepiestMinute()
        {
            int candidate = 0;
            int max = 0;
            for (int i=0;i<60;i++)
            {
                if (this.SleepRecord[i] > max) {
                    candidate = i;
                    max = this.SleepRecord[i];
                }
            }
            return candidate;
        }

        DateTime sleepTime;

        public Guard(int id)
        {
            this.Id = id;
            this.SleepRecord = new int[60];
            this.MinutesSlept = 0;
        }

        public void Sleep(DateTime time)
        {
            this.sleepTime = time;
        }

        public void Wake(DateTime time)
        {
            int sleepMinutes = 0;
            if (sleepTime.Hour == 0) sleepMinutes = sleepTime.Minute;
            int wakeMinutes = time.Minute;

            if (wakeMinutes < sleepMinutes)
                throw new ApplicationException(String.Format("Woke {0} before I slept {1}", time, sleepTime));

            for (int i=sleepMinutes;i<wakeMinutes;i++)
            {
                this.MinutesSlept++;
                this.SleepRecord[i]++;
            }
        }
    }
}