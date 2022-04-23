using AG.Yonetim.MVC.Data.Configurations;
using AG.Yonetim.MVC.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AG.Yonetim.MVC.Data.Contexts
{
    public class UserContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Bill> Bills { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new BillConfiguration());
            builder.Entity<Bill>()
            .HasOne(p => p.User)
            .WithMany(b => b.Bill).HasForeignKey(x => x.UserId);
            base.OnModelCreating(builder);
        }
    }
}
