using AG.Yonetim.MVC.Extensions;
using AG.Yonetim.MVC.Interfaces;
using AG.Yonetim.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AG.Yonetim.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new CreateUserModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                await _user.CreateUser(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);

        }

        public IActionResult SignIn()
        {
            return View(new SignInUserModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInUserModel model)
        {

            if (ModelState.IsValid)
            {
              var user =  await _user.SignInUser(model);
                HttpContext.Session.SetInt32("Userid", user.Id);
              //  HttpContext.Session.SetObject()
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
            await _user.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
