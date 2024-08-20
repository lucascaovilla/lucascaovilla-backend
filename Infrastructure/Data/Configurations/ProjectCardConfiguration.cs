using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    public class ProjectCardConfiguration : IEntityTypeConfiguration<ProjectCard>
    {
        public void Configure(EntityTypeBuilder<ProjectCard> builder)
        {
            builder.HasKey(hb => hb.Id);
            builder.Property(hb => hb.Title).IsRequired();
            builder.Property(hb => hb.Description).IsRequired();
            builder.Property(hb => hb.Link).IsRequired();
            builder.Property(hb => hb.CreatedAt).IsRequired();
            builder.Property(hb => hb.UpdatedAt).IsRequired();
        }
    }
}
