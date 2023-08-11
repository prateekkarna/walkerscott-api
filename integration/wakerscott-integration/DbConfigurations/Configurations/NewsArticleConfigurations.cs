using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using walkerscott_domain.Entities;

namespace wakerscott_integration.DbConfigurations.Configurations
{
    public class NewsArticleConfigurations : IEntityTypeConfiguration<NewsArticle>
    {
        public void Configure(EntityTypeBuilder<NewsArticle> entity)
        {
            entity.HasKey(e => e.ArticleId)
                .HasName("PK__NewsArticle");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.Property(e => e.Description).HasMaxLength(100);

            entity.Property(e => e.Title).HasMaxLength(50);

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);

            entity.HasOne(d => d.Category)
                .WithMany(p => p.NewsArticles)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__NewsArtic__Categ");

        }

    }
}
