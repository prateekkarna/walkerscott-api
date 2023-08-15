using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using walkerscott_domain.Entities;

namespace wakerscott_integration.DbConfigurations
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public virtual DbSet<NewsArticle> NewsArticles { get; set; }
        public virtual DbSet<NewsCategory> NewsCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.NewsArticleConfigurations());
            modelBuilder.ApplyConfiguration(new Configurations.NewsCategoryConfigurations());
            

        }

    }
}
