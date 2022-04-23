using Microsoft.AspNetCore.Identity;

namespace AG.Yonetim.MVC.Data.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public int Block { get; set; }
        public bool Situation { get; set; }
        public string RoomNumber { get; set; }
        public int TcNo { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string CarInfo { get; set; }
        public List<Bill> Bill { get; set; }
        public int BillId { get; set; }
    }
}
