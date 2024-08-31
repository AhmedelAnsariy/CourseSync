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
    public class InstallmentRepository : GenericRepository<Installment> , IInstallmentRepository
    {
        public InstallmentRepository( AppDbContext context) : base(context) { }
        
    }
}
