using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Configurations;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class PostgresDataContext : DbContext
    {
        public DbSet<HomeBanner> HomeBanner { get; set; }
        public DbSet<HomeAbout> HomeAbout { get; set; }
        public DbSet<TechnologyCard> TechnologyCard { get; set; }
        public DbSet<HomePortfolio> HomePortfolio { get; set; }
        public DbSet<ProjectCard> ProjectCard { get; set; }

        public PostgresDataContext(DbContextOptions<PostgresDataContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HomeBannerConfiguration());
            modelBuilder.ApplyConfiguration(new HomeAboutConfiguration());
            modelBuilder.ApplyConfiguration(new TechnologyCardConfiguration());
            modelBuilder.ApplyConfiguration(new HomePortfolioConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectCardConfiguration());
        }
    }
}
