using System;

namespace ScheduleHelper.Models.DbModels
{
    public class StudentScheduleItem
    {
        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public Guid ScheduleItemId { get; set; }

        public ScheduleItem ScheduleItem { get; set; }
    }
}
