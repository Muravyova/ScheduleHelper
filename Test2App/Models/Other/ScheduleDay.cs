using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleHelper.Models.Other
{
    public class ScheduleDay
    {
        public Int32 DayKey { get; set; }

        public String DayName { get; set; }

        public List<ScheduleTime> Times { get; set; }

    }
}
