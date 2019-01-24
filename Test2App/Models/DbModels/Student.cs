using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleHelper.Models.DbModels
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [MaxLength(50, ErrorMessage = "Поле не должно содержать больше 50 символов")]
        public String Name { get; set; }

       [Required(ErrorMessage="Поле должно быть заполнено")]
       [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage = "Некорректный номер")]
        public String PhoneNumber { get; set; }

        [Required(ErrorMessage="Поле должно быть заполнено")]
         [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public String Email { get; set; }

        [MaxLength(200, ErrorMessage = "Поле не должно содержать больше 200 символов")]
        public String Comment { get; set; } = null;

        public ICollection<Payment> Payments { get; set; } = null;

        public ICollection<StudentScheduleItem> ScheduleItems { get; set; } = null;

        public ICollection<History> Histories { get; set; } = null;
    }
}
