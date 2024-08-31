using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.DAL.Models
{
    public class Student : BaseEntity
    {

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "The phone number must contain only numbers.")]
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        public string Email { get; set; }
        public int TotalAmount { get; set; }
        public Schedule Schedule { get; set; }


        [Required(ErrorMessage = "Time Is Required")]
        public int?  ScheduleId { get; set; }
        public ICollection<Installment> Installments { get; set; }
        public ICollection<Attendance> Attendances { get; set; }

    }
}
