using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleHelper.Models.DbModels
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(200)]
        public String Name { get; set; }

        [Required]
        public String PhoneNumber { get; set; }

        [Required]
        public String Email { get; set; }

        public String Comment { get; set; } = null;

        public ICollection<Payment> Payments { get; set; } = null;

        public ICollection<StudentScheduleItem> ScheduleItems { get; set; } = null;

        public ICollection<History> Histories { get; set; } = null;
    }
}
