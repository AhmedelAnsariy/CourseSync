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
    public class ScheduleRepository : GenericRepository<Schedule> , IScheduleRepository
    {
        public ScheduleRepository( AppDbContext context) : base(context) { }
        


    }
}
