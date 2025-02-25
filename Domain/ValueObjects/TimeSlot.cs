using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillShare.Domain.ValueObjects
{
    public class TimeSlot
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public TimeSlot(DateTime start, DateTime end)
        {
            if (start >= end)
            {
                throw new ArgumentException("Start time must be before end time.");
            }

            Start = start;
            End = end;
        }

        public bool OverlapsWith(TimeSlot other)
        {
            return Start < other.End && End > other.Start;
        }
    }
}