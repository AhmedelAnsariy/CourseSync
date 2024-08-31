using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        public IStudentRepository StudentRepository { get; } 
        public IScheduleRepository ScheduleRepository { get; }
        public IInstallmentRepository InstallmentRepository {  get; }
        public IGroupNameRepository GroupNameRepository { get; }
        public IAttendanceRepository AttendanceRepository { get; }


        int Complete();



        
    }
}
