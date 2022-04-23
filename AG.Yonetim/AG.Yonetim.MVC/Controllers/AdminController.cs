using AG.Yonetim.MVC.Data.Contexts;
using AG.Yonetim.MVC.Data.Entities;
using AG.Yonetim.MVC.Interfaces;
using AG.Yonetim.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AG.Yonetim.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUser _user;
        private readonly IMapper _mapper;
        private readonly IBill _bill;
        public AdminController(IUser user, IMapper mapper, IBill bill)
        {
            _user = user;
            _mapper = mapper;
            _bill = bill;
        
        }
        public async Task<IActionResult> Index()
        {
            var users = await _user.GetUser();
            return View(users);
        }

        public async Task<IActionResult> Update(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var user = await _user.GetById(id);
            var userMapper = _mapper.Map<UpdateUserModel>(user);
            return View(userMapper);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(UpdateUserModel model)
        {
            await _user.updateUser(model);
            return View(model);
        }

        public IActionResult Create()
        {
            return View(new CreateUserAdminPanelModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserAdminPanelModel model)
        {
            var modelMapper = _mapper.Map<CreateUserModel>(model);
            await _user.CreateUser(modelMapper);
            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _user.DeleteUser(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Bill()
        {

            return View(new CreateBillModel());
        }
        [HttpPost]
        public async Task<IActionResult> Bill(CreateBillModel model)
        {
            await _bill.CreateBill(model);
            return View(model);
        }

        public async Task<IActionResult> GetBill()
        {
            //var bills = await _bill.GetBill();
            //return View(bills.AsEnumerable());
          //  var query = from user in _context.Set<AppUser>() join bill in _context.Set<Bill>() on user.Id equals bill.UserId select new { user.UserName, bill };
            var query = await _bill.GetBill();
            // var list = query.ToList();
            return View(query);
        }
    }
}
