using AG.Yonetim.MVC.Data.Entities;
using AG.Yonetim.MVC.Models;

namespace AG.Yonetim.MVC.Interfaces
{
    public interface IBill
    {
        public Task<CreateBillModel> CreateBill(CreateBillModel model);
        public Task<IEnumerable<BillUserViewModel>> GetBill();
        public Task<IEnumerable<BillUserViewModel>> GetBillById(int id);
    }
}
