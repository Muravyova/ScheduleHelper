using ScheduleHelper.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleHelper.Models.Other
{
    public class ScheduleTime
    {
        public String StartTime { get; set; }

        public List<ScheduleItem> Items { get; set; }

    }
}
