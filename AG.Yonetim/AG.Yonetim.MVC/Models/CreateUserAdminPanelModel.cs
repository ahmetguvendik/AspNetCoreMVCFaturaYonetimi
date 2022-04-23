namespace AG.Yonetim.MVC.Models
{
    public class CreateUserAdminPanelModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int TcNo { get; set; }
        public int Block { get; set; }
        public bool Situation { get; set; }
        public string RoomNumber { get; set; }
        public string? CarInfo { get; set; }
    }
}
