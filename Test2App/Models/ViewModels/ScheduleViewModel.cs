using ScheduleHelper.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleHelper.Models.ViewModels
{
    public class ScheduleViewModel
    {
        public DateTime CurrentWeek { get; set; }

        public List<ScheduleDay> Days { get; set; }

        public DateTime? Time { get; set; }
    }
}
