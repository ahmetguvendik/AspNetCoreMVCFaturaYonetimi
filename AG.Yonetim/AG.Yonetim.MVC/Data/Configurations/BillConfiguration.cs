using AG.Yonetim.MVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AG.Yonetim.MVC.Data.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.Property(x => x.Id).HasColumnName("bill_id");
            builder.Property(x => x.Name).HasColumnName("bill_name");
            builder.Property(x => x.Price).HasColumnName("bill_price");
           
        }
    }
}
