using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.DAL.Models
{
    public class Attendance : BaseEntity
    {
        
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsComed { get; set; }


        public Student Student { get; set; }
        public int StudentId { get; set; }
    }


}
