using AG.Yonetim.MVC.Data.Entities;
using AG.Yonetim.MVC.Models;

namespace AG.Yonetim.MVC.Interfaces
{
    public interface IUser
    {
        public Task<CreateUserModel> CreateUser(CreateUserModel model);
        public Task<SignInUserModel> SignInUser(SignInUserModel model);
        public Task SignOut();
        public Task<List<AppUser>> GetUser();
        public Task updateUser(UpdateUserModel model);
        public Task<AppUser> GetById(int id);
        public Task DeleteUser(int id);
     
    }
}
