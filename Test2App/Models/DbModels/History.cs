using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleHelper.Models.DbModels
{
    public class History
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public String Time { get; set; }

        public String Comment { get; set; } = null;

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Student Student { get; set; }

        [Required]
        public Guid ScheduleItemId { get; set; }

        [Required]
        public ScheduleItem ScheduleItem { get; set; }
    }
}
