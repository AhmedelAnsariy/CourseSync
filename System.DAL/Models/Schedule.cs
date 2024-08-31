using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.DAL.Models
{
    public class Schedule : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }


        public string FamousStudent { get; set; }

        public GroupName GroupName { get; set; }

        [Required(ErrorMessage = "Day is required")]
        public int? GroupNameId { get; set; }


        public ICollection<Student> Students { get; set; } 
    }


}



