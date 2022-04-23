using AG.Yonetim.MVC.Data.Contexts;
using AG.Yonetim.MVC.Data.Entities;
using AG.Yonetim.MVC.Interfaces;
using AG.Yonetim.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AG.Yonetim.MVC.Repositories
{
    public class UserRepository : IUser
    {
        private readonly UserContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        public UserRepository(UserContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<CreateUserModel> CreateUser(CreateUserModel model)
        {
            var users = await _context.Users.SingleOrDefaultAsync(x => x.TcNo == model.TcNo);
            if (users == null)
            {
                var appUser = new AppUser()
                {
                    UserName = model.UserName,
                    TcNo = model.TcNo,
                    Situation = model.Situation,
                    Email = model.Email,
                    CarInfo = model.CarInfo,
                    PhoneNumber = model.PhoneNumber,
                    RoomNumber = model.RoomNumber,
                };
                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    var role = await _roleManager.FindByNameAsync("Member");
                    if (role == null)
                    {
                        var appRole = new AppRole()
                        {
                            Name = "Member"
                        };
                        await _roleManager.CreateAsync(appRole);
                    }

                    await _userManager.AddToRoleAsync(appUser, "Member");
                }

            }
            return model;

        }

        public async Task DeleteUser(int id)
        {
            var removedPerson = await _context.Users.FindAsync(id);
            if (id != null)
            {
                _context.Users.Remove(removedPerson);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<AppUser> GetById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }



        public async Task<List<AppUser>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<SignInUserModel> SignInUser(SignInUserModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
            if (signInResult.Succeeded)
            {
                var role = await _userManager.GetRolesAsync(user);
                var userId = await _userManager.FindByIdAsync(user.Id.ToString());
                if (role.Contains("Member"))
                {

                }
            }
            var userMapper = _mapper.Map<SignInUserModel>(user);
            return userMapper;

        }




        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task updateUser(UpdateUserModel model)
        {
            var entity = await _context.Users.FindAsync(model.Id);
            if (entity != null)
            {
                entity.TcNo = model.TcNo != default ? entity.TcNo : model.TcNo;
                entity.Email = string.IsNullOrEmpty(model.Email) ? entity.Email : model.Email;
                entity.Block = model.Block != default ? model.Block : model.Block;
                entity.CarInfo = String.IsNullOrEmpty(model.CarInfo) ? model.CarInfo : model.CarInfo;
                entity.PhoneNumber = model.PhoneNumber != default ? model.PhoneNumber : model.PhoneNumber;
                entity.RoomNumber = String.IsNullOrEmpty(model.RoomNumber) ? model.RoomNumber : model.RoomNumber;
            }
            await _context.SaveChangesAsync();
        }
    }
}
