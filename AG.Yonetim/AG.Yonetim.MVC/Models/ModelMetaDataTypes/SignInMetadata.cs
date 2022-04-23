using System.ComponentModel.DataAnnotations;

namespace AG.Yonetim.MVC.Models.ModelMetaDataTypes
{
    public class SignInMetadata
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
