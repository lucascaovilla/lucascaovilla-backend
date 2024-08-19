using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    public class TechnologyCardConfiguration : IEntityTypeConfiguration<TechnologyCard>
    {
        public void Configure(EntityTypeBuilder<TechnologyCard> builder)
        {
            builder.HasKey(hb => hb.Id);
            builder.Property(hb => hb.Name).IsRequired();
            builder.Property(hb => hb.Class).IsRequired();
            builder.Property(hb => hb.CreatedAt).IsRequired();
            builder.Property(hb => hb.UpdatedAt).IsRequired();
        }
    }
}
