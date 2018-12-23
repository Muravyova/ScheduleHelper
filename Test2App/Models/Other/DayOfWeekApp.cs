using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleHelper.Models.Other
{

    public class DayOfWeekApp
    {

        public static List<DayOfWeekApp> DAYS_OF_WEEK = new List<DayOfWeekApp> {
            new DayOfWeekApp(1, "Понедельник"),
            new DayOfWeekApp(2, "Вторник"),
            new DayOfWeekApp(3, "Среда"),
            new DayOfWeekApp(4, "Четверг"),
            new DayOfWeekApp(5, "Пятница"),
            new DayOfWeekApp(6, "Суббота"),
            new DayOfWeekApp(7, "Воскресенье")
        };

        private DayOfWeekApp(Int32 key, String name)
        {
            Key = key;
            Name = name;
        }

        public Int32 Key { get; set; }

        public String Name { get; set; }

    }
}
