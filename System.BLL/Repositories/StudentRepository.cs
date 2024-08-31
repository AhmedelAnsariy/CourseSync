using Microsoft.EntityFrameworkCore;
using System;
using System.BLL.Interfaces;
using System.Collections.Generic;
using System.DAL.Data;
using System.DAL.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.BLL.Repositories
{
    public class StudentRepository : GenericRepository<Student> , IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
            
        }

        public IEnumerable<Student> GetByPhone(string phoneNumber)
        {
          return _context.Students.Where( s=>s.Phone.Contains(phoneNumber)  ).Include(s=>s.Schedule) ;
        }
    }
}
