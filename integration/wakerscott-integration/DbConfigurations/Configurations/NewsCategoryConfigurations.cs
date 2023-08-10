using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using walkerscott_domain.Entities;

namespace wakerscott_integration.DbConfigurations.Configurations
{
    public class NewsCategoryConfigurations : IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> entity)
        {
            entity.HasKey(e => e.CategoryId)
                .HasName("PK__NewsCate");

            entity.ToTable("NewsCategory");

            entity.Property(e => e.CategoryName).HasMaxLength(50);

        }

    }
}

