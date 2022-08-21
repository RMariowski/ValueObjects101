using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValueObjects101.Domain.Articles;

namespace ValueObjects101.Infrastructure.Database.EntityTypeConfigurations;

public class ArticleEntityTypeConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.HasKey(article => article.Id);
        builder.Property(article => article.Id)
            .IsRequired();

        builder.Property(article => article.Text)
            .IsRequired();
        
        builder.Property(article => article.CreatedAt)
            .IsRequired();
    }
}
