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
    public class GroupNameRepository : GenericRepository<GroupName> , IGroupNameRepository
    {
        public GroupNameRepository(AppDbContext context ) : base( context ) 
        {
            
        }


    }
}
