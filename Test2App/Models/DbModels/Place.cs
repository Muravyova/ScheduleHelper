using System;

namespace ScheduleHelper.Models.DbModels
{
    public class Place
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public String Type { get; set; } = null;

    }
}
