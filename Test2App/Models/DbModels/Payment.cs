using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleHelper.Models.DbModels
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Double Pay { get; set; }

        [Required]
        public Int32 Count { get; set; }

        public Boolean Refund { get; set; } = false;

        public Double RefundPay { get; set; } = 0;

        [Required]
        public Guid ScheduleItemId { get; set; }

        [Required]
        public ScheduleItem ScheduleItem { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Student Student { get; set; }
    }
}
