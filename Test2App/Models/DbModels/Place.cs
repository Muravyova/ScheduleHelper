using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleHelper.Models.DbModels
{
    public class Place
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [MaxLength(50, ErrorMessage = "Поле не должно содержать больше 50 символов")]
        public String Type { get; set; } = null;

    }
}
