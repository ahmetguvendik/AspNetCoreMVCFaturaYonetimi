using System.ComponentModel.DataAnnotations;

namespace AG.Yonetim.MVC.Models.ModelMetaDataTypes
{
    public class UserMetadata
    {
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]       
        public int PhoneNumber { get; set; }
        [Required]
        public int TcNo { get; set; }
        [Required]
        public int Block { get; set; }
        [Required]
        public bool Situation { get; set; }
        [Required]
        public string RoomNumber { get; set; }
        public string? CarInfo { get; set; }
    }
}
