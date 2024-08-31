using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.DAL.Models
{
    public class GroupName : BaseEntity
    {
        [Required(ErrorMessage = "Day name is required")]
        public string DayName { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}



