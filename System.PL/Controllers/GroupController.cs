using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.BLL.Interfaces;
using System.DAL.Models;

namespace System.PL.Controllers
{

    [Authorize]
    public class GroupController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult Index()
        {

            var groups = _unitOfWork.GroupNameRepository.GetAll();
            return View(groups);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(GroupName model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.GroupNameRepository.Add(model);
        //        var count = _unitOfWork.Complete();
        //        if (count > 0)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }


        //    }



        //    return View(model);

        //}



        [HttpPost]
        public IActionResult Create(GroupName model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.GroupNameRepository.Add(model);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }


                catch (DbUpdateException ex)
                {
                    if (ex.InnerException is SqlException sqlException && sqlException.Number == 2627)
                    {
                        ViewBag.ErrorMessage = "Duplicate value detected. Please enter a unique value.";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "There is Day Already With this Name";
                    }
                }

                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "An unexpected error occurred. Please try again.";
                }


            }
            return View(model);


        }



       

    }

}
