using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleHelper.Models.DbModels
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public Double Pay { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public Int32 Count { get; set; }

        public Boolean Refund { get; set; } = false;

        public Double RefundPay { get; set; } = 0;

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public Guid ScheduleItemId { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public ScheduleItem ScheduleItem { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public Guid StudentId { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public Student Student { get; set; }
    }
}
