using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleHelper.Models.DbModels
{
    public class Language
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public String Name { get; set; }

        public String Description { get; set; } = null;

        public ICollection<ScheduleItem> ScheduleItems { get; set; } = null;
    }
}
