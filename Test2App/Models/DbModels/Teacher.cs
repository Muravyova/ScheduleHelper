using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleHelper.Models.DbModels
{
    public class Teacher
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public String Name { get; set; }

        [Required]
        public String PhoneNumber { get; set; }

        [Required]
        public String Email { get; set; }

        public String Comment { get; set; } = null;

        public ICollection<ScheduleItem> ScheduleItems { get; set; } = null;
    }
}
