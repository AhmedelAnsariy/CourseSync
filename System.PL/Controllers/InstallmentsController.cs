using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.BLL.Interfaces;
using System.DAL.Models;

namespace System.PL.Controllers
{


    [Authorize]
    public class InstallmentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public InstallmentsController( IUnitOfWork  unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }




        public IActionResult Index()
        {
            var data = _unitOfWork.StudentRepository.GetAll();
            return View(data);
        }


        [HttpGet]
        public IActionResult NewInstallment(int id ) {
        
            var student = _unitOfWork.StudentRepository.GetById(id);
            var data = _unitOfWork.GroupNameRepository.GetAll();
            var ReturnedView = new Installment
            {
                StudentId = student.Id,
                Student = student,
                PaymentDate = DateTime.Now
            };
            return View(ReturnedView);
        }


        [HttpPost]
        public IActionResult NewInstallment(Installment model)
        {
            if (ModelState.IsValid)
            {
                model.Student = _unitOfWork.StudentRepository.GetById(model.StudentId);

                model.Student.TotalAmount -= model.Amount;
                if(model.Student.TotalAmount < 0)
                {
                    model.Student.TotalAmount = 0;
                }


                var sendToDb = new Installment
                {
                    Student = model.Student,
                    StudentId = model.StudentId,
                    Amount = model.Amount,
                    PaymentDate = model.PaymentDate,
                    Method = model.Method,
                };



                _unitOfWork.InstallmentRepository.Add(sendToDb);
                var count = _unitOfWork.Complete();
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));

                }

            }
            return View(model);

        }



        [HttpGet]
        public IActionResult DetailsInstallments(int id)
        {
            var student = _unitOfWork.StudentRepository.GetById(id);
            var allSchedules = _unitOfWork.GroupNameRepository.GetAll();

            if (student == null)
            {
                return BadRequest();
            }

            return View(student);

        }












    }
}
