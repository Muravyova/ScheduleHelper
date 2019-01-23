using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleHelper.Models.DbModels
{
    public class History
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public String Time { get; set; }

        [MaxLength(200, ErrorMessage = "Поле не должно содержать больше 200 символов")]
        public String Comment { get; set; } = null;

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public Guid StudentId { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public Student Student { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public Guid ScheduleItemId { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public ScheduleItem ScheduleItem { get; set; }
    }
}
