using System;
using System.Collections.Generic;
using System.DAL.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
         IEnumerable<T> GetAll();

         T GetById(int id);

         void Add(T entity);
         void Update(T entity);

         void Delete(T entity);
    }
}
