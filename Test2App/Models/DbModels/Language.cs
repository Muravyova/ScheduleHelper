using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleHelper.Models.DbModels
{
    public class Language
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [MaxLength(100, ErrorMessage = "Поле не должно содержать больше 100 символов")]
        public String Name { get; set; }

        [MaxLength(200, ErrorMessage = "Поле не должно содержать больше 200 символов")]
        public String Description { get; set; } = null;

        public ICollection<ScheduleItem> ScheduleItems { get; set; } = null;
    }
}
