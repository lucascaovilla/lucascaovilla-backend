using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    public class HomeBannerConfiguration : IEntityTypeConfiguration<HomeBanner>
    {
        public void Configure(EntityTypeBuilder<HomeBanner> builder)
        {
            builder.HasKey(hb => hb.Id);
            builder.Property(hb => hb.BackgroundImageSrc).IsRequired();
            builder.Property(hb => hb.BackgroundImageAlt).IsRequired();
            builder.Property(hb => hb.BackgroundImageWidth).IsRequired();
            builder.Property(hb => hb.BackgroundImageHeight).IsRequired();
            builder.Property(hb => hb.CreatedAt).IsRequired();
            builder.Property(hb => hb.UpdatedAt).IsRequired();
        }
    }
}
