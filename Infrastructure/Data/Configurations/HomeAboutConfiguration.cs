using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    public class HomeAboutConfiguration : IEntityTypeConfiguration<HomeAbout>
    {
        public void Configure(EntityTypeBuilder<HomeAbout> builder)
        {
            builder.HasKey(hb => hb.Id);
            builder.Property(hb => hb.Description).IsRequired();
            builder.Property(hb => hb.Caption).IsRequired();
            builder.Property(hb => hb.CreatedAt).IsRequired();
            builder.Property(hb => hb.UpdatedAt).IsRequired();
        }
    }
}
