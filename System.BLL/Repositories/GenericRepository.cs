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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
           _context = context;
        }




        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }



        public void Update(T entity)
        {
            _context.Update(entity);
        }







        public IEnumerable<T> GetAll()
        {

            if (typeof(T) == typeof(GroupName))
            {
                return (IEnumerable<T>)_context.GroupNames.Include(g => g.Schedules).ToList();
            }


            else if (typeof(T) == typeof(Schedule))
            {
                return (IEnumerable<T>)_context.Schedules.Include(s => s.GroupName).Include(s=>s.Students).ToList();
            }

            else if(typeof(T) == typeof(Student))
            {
                return (IEnumerable<T>) _context.Students.Include(s=>s.Schedule).Include(s=>s.Attendances).Include(s=>s.Installments).ToList();
            }



            else if (typeof(T) == typeof(Attendance))
            {
                return (IEnumerable<T>)_context.Attendances.Include(s => s.Student);
            }


            else if (typeof(T) == typeof(Installment))
            {
                return (IEnumerable<T>)_context.Installments.Include(s => s.Student);
            }







            else
            {
                return _context.Set<T>().ToList();

        }

    }



        public T GetById(int id)
        {
            T data = default;

            if (typeof(T) == typeof(Schedule))
            {
                data = (T)(object)_context.Schedules
                                           .Include(s => s.GroupName)
                                           .Include(s=> s.Students)
                                           .FirstOrDefault(s => s.Id == id);
            }

            if(typeof(T) == typeof(Student))
            {
                data = (T) (object) _context.Students
                                            .Include(s=>s.Schedule)
                                            .Include(s=>s.Attendances)
                                            .Include(s=>s.Installments)
                                            .FirstOrDefault(s=>s.Id == id);
            }


            if (typeof(T) == typeof(Attendance))
            {
                data = (T)(object)_context.Attendances
                                            .Include(s => s.Student)
                                            .FirstOrDefault(s => s.Id == id);
            }


            if (typeof(T) == typeof(Installment))
            {
                data = (T)(object)_context.Installments
                                            .Include(s => s.Student)
                                            .FirstOrDefault(s => s.Id == id);
            }









            else
            {
                data = _context.Set<T>().Find(id);
            }

            return data;
        }




    }
}
