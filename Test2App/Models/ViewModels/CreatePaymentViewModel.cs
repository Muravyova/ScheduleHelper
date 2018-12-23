using ScheduleHelper.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleHelper.Models.ViewModels
{
    public class CreatePaymentViewModel
    {
        public Student Student { get; set; }

        public DateTime Date { get; set; }
   
        public Double Pay { get; set; }
        
        public Int32 Count { get; set; }
    }
}
