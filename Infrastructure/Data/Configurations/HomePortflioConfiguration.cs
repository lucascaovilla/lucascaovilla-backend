using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    public class HomePortfolioConfiguration : IEntityTypeConfiguration<HomePortfolio>
    {
        public void Configure(EntityTypeBuilder<HomePortfolio> builder)
        {
            builder.HasKey(hb => hb.Id);
            builder.Property(hb => hb.BackgroundImageSrc).IsRequired();
            builder.Property(hb => hb.CreatedAt).IsRequired();
            builder.Property(hb => hb.UpdatedAt).IsRequired();
        }
    }
}
