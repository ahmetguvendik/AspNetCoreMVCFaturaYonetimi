using AG.Yonetim.MVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AG.Yonetim.MVC.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.UserName).IsRequired(true);
            builder.Property(x => x.CarInfo).IsRequired(false);

        }
    }
}
