using AG.Yonetim.MVC.Data.Entities;
using AG.Yonetim.MVC.Interfaces;
using AG.Yonetim.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AG.Yonetim.MVC.Controllers
{
    [Authorize(Roles = "Member")]
    public class MemberController : Controller
    {
        private readonly IBill _bill;
        public MemberController(IBill bill)
        {
            _bill = bill;
        }

        public async Task<IActionResult> Index()
        {
            int id = (int)HttpContext.Session.GetInt32("Userid");
            var bill = await _bill.GetBillById(id);
            if (bill == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(bill);
        }



    }
}
