using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleHelper.Models.DbModels
{
    public class ScheduleItem
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [MaxLength(100, ErrorMessage = "Поле не должно содержать больше 100 символов")]
        public String Title { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public Int32 DayOfWeek { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public String StartTime { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public Int32 Duration { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public String Type { get; set; }

        public Guid? PlaceId { get; set; } = null;

        public Place Place { get; set; } = null;

        public ICollection<StudentScheduleItem> Students { get; set; } = null;

        public Guid? TeacherId { get; set; } = null;

        public Teacher Teacher { get; set; } = null;

        public Guid? LanguageId { get; set; } = null;

        public Language Language { get; set; } = null;
    }
}
