using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.DAL.Models;
using System.Linq;
using System.PL.Models;
using System.Threading.Tasks;

namespace System.PL.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController( UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task< IActionResult> Index()
        {
            var users = Enumerable.Empty<UserViewModel>();
            users = await _userManager.Users.Select(u => new UserViewModel()
            {
                FirstName = u.FName,
                LastName = u.LName,
                Email = u.Email,
      
            }).ToListAsync();
            return View(users);
        }


 
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        Email = model.Email,
                        FName = model.FName,
                        LName = model.LName,
                        UserName = model.FName
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Student");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User already exists");
                }
            }

            // Return the model with the password fields preserved
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (passwordValid)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Student");
                        }
                    }
                }

                // If we reach this point, it means the login attempt was unsuccessful
                ModelState.AddModelError(string.Empty, "Invalid Email Or Password.");
            }

           
            return View(model);
        }


        public async new Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Account");
        }



        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{

        //}


    }
}
