using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.BLL.Interfaces;
using System.DAL.Models;

namespace System.PL.Controllers
{

    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult Index()
        {
            var data = _unitOfWork.ScheduleRepository.GetAll();
            return View(data);
        }



        [HttpGet]
        public IActionResult Create()
        {

            ViewData["GroupNames"] = _unitOfWork.GroupNameRepository.GetAll();
            return View();
        }




        [HttpPost]
        public IActionResult Create(Schedule model)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    ViewData["GroupNames"] = _unitOfWork.GroupNameRepository.GetAll();
                    _unitOfWork.ScheduleRepository.Add(model);
                    var count = _unitOfWork.Complete();
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));

                    }
                   
                   
                }catch (Exception ex)
                {
                    if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627) // 2627 is the error number for unique constraint violation
                    {
                        ViewBag.ErrorMessage = "A schedule with the same name and group already exists.";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "A schedule with the same name and group already exists.";
                    }
                }

             

            }
            return View(model);
        }





        public IActionResult Details(int? id)
        {
            if(id is null)
            {
                return BadRequest();
            }

            var OneSchedule = _unitOfWork.ScheduleRepository.GetById(id.Value);

            if(OneSchedule is null)
            {
                return NotFound();
            }

            return View(OneSchedule);
        }




















    }
}
