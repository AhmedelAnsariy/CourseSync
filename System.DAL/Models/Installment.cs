using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.DAL.Models
{
    public class Installment : BaseEntity
    {

        [Required(ErrorMessage ="Amount Is Required")]
        public int Amount { get; set; }
        public PaymentMethod Method { get; set; }
        public DateTime PaymentDate { get; set; }


        public enum PaymentMethod
        {
            Cash,
            Online
        }





        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
