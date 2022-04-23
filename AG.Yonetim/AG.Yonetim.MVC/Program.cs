using AG.Yonetim.MVC.Data.Contexts;
using AG.Yonetim.MVC.Data.Entities;
using AG.Yonetim.MVC.Interfaces;
using AG.Yonetim.MVC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<UserContext>();
builder.Services.AddDbContext<UserContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IBill, BillRepository>();
builder.Services.AddDistributedMemoryCache();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict; //Ýlgili Domainden kullanýlýr sadece
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; //HTTP ile gelirse HTTP , HTTPS ile gelirse HTTPS ile çalýþýr.
    opt.Cookie.Name = "AGCookie";
    opt.ExpireTimeSpan = TimeSpan.FromDays(10); //Ýlgili Cookieler 20 gün saklanýr.
    opt.LoginPath = new PathString("/Home/SignIn"); //Yetkisiz giriþ oluþunca gideceði yer
    opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
}
);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapDefaultControllerRoute();

app.Run();
