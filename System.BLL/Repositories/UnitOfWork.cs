using System;
using System.BLL.Interfaces;
using System.Collections.Generic;
using System.DAL.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private IStudentRepository studentRepository;
        private IScheduleRepository scheduleRepository;
        private IInstallmentRepository installmentRepository;
        private IGroupNameRepository groupNameRepository;
        private IAttendanceRepository attendanceRepository;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            studentRepository = new StudentRepository(context);
            scheduleRepository = new ScheduleRepository(context);
            installmentRepository = new InstallmentRepository(context);
            attendanceRepository = new AttendanceRepository(context);
            groupNameRepository = new GroupNameRepository(context);
        }



        public IStudentRepository StudentRepository => studentRepository;

        public IScheduleRepository ScheduleRepository => scheduleRepository;

        public IInstallmentRepository InstallmentRepository => installmentRepository;

        public IGroupNameRepository GroupNameRepository => groupNameRepository;

        public IAttendanceRepository AttendanceRepository => attendanceRepository;




        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();   
        }
    }
}
