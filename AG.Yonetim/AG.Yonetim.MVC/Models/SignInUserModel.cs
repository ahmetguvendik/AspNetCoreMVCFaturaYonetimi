using AG.Yonetim.MVC.Models.ModelMetaDataTypes;
using Microsoft.AspNetCore.Mvc;

namespace AG.Yonetim.MVC.Models
{
    [ModelMetadataType(typeof(SignInMetadata))]
    public class SignInUserModel
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
