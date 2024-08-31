using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.BLL.Interfaces;
using System.DAL.Models;
using System.Linq;

namespace System.PL.Controllers
{


    [Authorize]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult Index(string searchinput)
        {
            var days = _unitOfWork.GroupNameRepository.GetAll(); 

            var students = Enumerable.Empty<Student>();

            if (string.IsNullOrEmpty(searchinput))
            {
                students = _unitOfWork.StudentRepository.GetAll();
            }
            else
            {
                students = _unitOfWork.StudentRepository.GetByPhone(searchinput);
            }

            return View(students);


        }


        public IActionResult Create()
        {
      

            var groupNames = _unitOfWork.GroupNameRepository.GetAll();
            var schedules = _unitOfWork.ScheduleRepository.GetAll();

            ViewBag.GroupNames = groupNames;
            ViewBag.Schedules = schedules;

            return View();
        }








        [HttpPost]
        public IActionResult Create(Student model)
        {
            var groupNames = _unitOfWork.GroupNameRepository.GetAll();
            var schedules = _unitOfWork.ScheduleRepository.GetAll();

            ViewBag.GroupNames = groupNames;
            ViewBag.Schedules = schedules;

            if (ModelState.IsValid)
            {


                try
                {
                    _unitOfWork.StudentRepository.Add(model);
                    var count = _unitOfWork.Complete();
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Phone Number Must Be Uniqe";
                }



            




            }


            return View();
        }


        [HttpGet]
        public IActionResult DetailsPlace(int? id)
        {

            if(id is null)
            {
                return BadRequest(); 
            }

            var groupNames = _unitOfWork.GroupNameRepository.GetAll();
            var schedules = _unitOfWork.ScheduleRepository.GetAll();
            ViewBag.GroupNames = groupNames;
            ViewBag.Schedules = schedules;


            var OneStudent = _unitOfWork.StudentRepository.GetById(id.Value);
            if (OneStudent is null)
            {
                return NotFound();
            }
            return View(OneStudent);

        }



        [HttpGet]
        public IActionResult EditStudentPlace(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var groupNames = _unitOfWork.GroupNameRepository.GetAll();
            var schedules = _unitOfWork.ScheduleRepository.GetAll();

            ViewBag.GroupNames = groupNames;
            ViewBag.Schedules = schedules;



            var OneStudent = _unitOfWork.StudentRepository.GetById(id.Value);
            if (OneStudent is null)
            {
                return NotFound();
            }


            return View(OneStudent);
        }




        [HttpPost]
        public IActionResult EditStudentPlace(Student model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.StudentRepository.Update(model);
                var count = _unitOfWork.Complete();
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }


            return View(model);

        }


        [HttpGet]
        public IActionResult DeleteStudent(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var groupNames = _unitOfWork.GroupNameRepository.GetAll();
            var schedules = _unitOfWork.ScheduleRepository.GetAll();
            ViewBag.GroupNames = groupNames;
            ViewBag.Schedules = schedules;


            var OneStudent = _unitOfWork.StudentRepository.GetById(id.Value);
            if (OneStudent is null)
            {
                return NotFound();
            }
            return View(OneStudent);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudent([FromRoute] int? id, Student model)
        {
            if (id == null || id != model.Id)
            {
                return BadRequest();
            }



           
                _unitOfWork.StudentRepository.Delete(model);
                var count = _unitOfWork.Complete();


                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while deleting the student.");
                }
            

            return View(model);
        }




    }
}
