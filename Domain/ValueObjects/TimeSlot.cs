using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillShare.Domain.ValueObjects
{
    public class TimeSlot
    {
        private TimeSlot() { }
         public TimeSlot(DateTime startTime, DateTime endTime)
        {
            if (startTime >= endTime)
            {
                throw new ArgumentException("Start time must be before end time.");
            }

            StartTime = startTime;
            EndTime = endTime;
        }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public bool Overlaps(TimeSlot other)
        {
            return StartTime < other.EndTime && EndTime > other.StartTime;
        }
    }
}