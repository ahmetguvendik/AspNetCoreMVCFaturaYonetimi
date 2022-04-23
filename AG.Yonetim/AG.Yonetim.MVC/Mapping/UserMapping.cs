using AG.Yonetim.MVC.Data.Entities;
using AG.Yonetim.MVC.Models;
using AutoMapper;

namespace AG.Yonetim.MVC.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, UpdateUserModel>();
            CreateMap<UpdateUserModel, AppUser>();
            CreateMap<CreateUserModel, CreateUserAdminPanelModel>();
            CreateMap<CreateUserAdminPanelModel, CreateUserModel>();
            CreateMap<AppUser, SignInUserModel>();
            CreateMap<SignInUserModel, AppUser>();
        }

    }
}
