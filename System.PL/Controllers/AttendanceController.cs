using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.BLL.Interfaces;
using System.Collections.Generic;
using System.DAL.Models;
using System.Linq;


namespace System.PL.Controllers
{

    [Authorize]
    public class AttendanceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendanceController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            var data = _unitOfWork.StudentRepository.GetAll();
            return View(data);
        }







        [HttpGet]
        public IActionResult TakeOne(int id)
        {
            var student = _unitOfWork.StudentRepository.GetById(id);
            var data = _unitOfWork.GroupNameRepository.GetAll();
            var returnedView = new Attendance
            {
                StudentId = id,
                Student = student,
                Date = DateTime.Now
            };
            return View(returnedView);
        }















        [HttpPost]
        public IActionResult TakeOne(Attendance model)
        {
            if (ModelState.IsValid)
            {
                model.Student = _unitOfWork.StudentRepository.GetById(model.StudentId);

                var sendToDb = new Attendance
                {
                    Student = model.Student,
                    StudentId = model.StudentId,
                    IsComed = model.IsComed,
                    Date = model.Date
                };

               

                
                    _unitOfWork.AttendanceRepository.Add(sendToDb);
                    var count = _unitOfWork.Complete();
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));

                    }




                
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult DetailsAttendance(int id)
        {
            var student = _unitOfWork.StudentRepository.GetById(id);
            var allSchedules = _unitOfWork.GroupNameRepository.GetAll();

            if(student == null)
            {
                return BadRequest();
            }

            return View(student);

        }



























    }
}
