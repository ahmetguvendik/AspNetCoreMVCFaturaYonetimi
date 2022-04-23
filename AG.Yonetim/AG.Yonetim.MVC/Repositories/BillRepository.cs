using AG.Yonetim.MVC.Data.Contexts;
using AG.Yonetim.MVC.Data.Entities;
using AG.Yonetim.MVC.Interfaces;
using AG.Yonetim.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AG.Yonetim.MVC.Repositories
{
    public class BillRepository : IBill
    {
        private readonly UserContext _context;
        public BillRepository(UserContext context)
        {
            _context = context;
        }
        public async Task<CreateBillModel> CreateBill(CreateBillModel model)
        {
            var bill = new Bill();
            bill.Name = model.Name;
            bill.Price = model.Price;
            bill.UserId = model.Id;
            await _context.Bills.AddAsync(bill);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<IEnumerable<BillUserViewModel>> GetBill()
        {
            var query = (from bill in _context.Set<Bill>()
                         join user in _context.Set<AppUser>()
                            on bill.UserId equals user.Id
                         //where user.Id == 7 
                         select new BillUserViewModel() { Name = bill.Name, Price = bill.Price, UserName = user.UserName }).ToList<BillUserViewModel>();
            return query;
        }

        public async Task<IEnumerable<BillUserViewModel>> GetBillById(int id)
        {
            var query = (from bill in _context.Set<Bill>()
                         join user in _context.Set<AppUser>()
                            on bill.UserId equals user.Id
                         where user.Id == id
                         select new BillUserViewModel() { Name = bill.Name, Price = bill.Price }).ToList();
            return query;
        }


    }
}
