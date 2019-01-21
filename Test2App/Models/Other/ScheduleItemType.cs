using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleHelper.Models.Other
{
    public class ScheduleItemType
    {

        public static List<ScheduleItemType> TYPES = new List<ScheduleItemType>
        {
            new ScheduleItemType("Групповое занятие"),
            new ScheduleItemType("Преподавательское"),
            new ScheduleItemType("Индивидуальное занятие"),
            new ScheduleItemType("Открытое мероприятие"),
            new ScheduleItemType("Онлайн")
        };

        private ScheduleItemType(String key)
        {
            Key = key;
        }

        public String Key { get; set; }
    }
}
