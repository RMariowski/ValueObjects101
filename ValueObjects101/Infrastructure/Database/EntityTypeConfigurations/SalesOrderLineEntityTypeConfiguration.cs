using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValueObjects101.Domain.Orders;

namespace ValueObjects101.Infrastructure.Database.EntityTypeConfigurations;

public class SalesOrderLineEntityTypeConfiguration : IEntityTypeConfiguration<SalesOrderLine>
{
    public void Configure(EntityTypeBuilder<SalesOrderLine> builder)
    {
        builder.HasKey(line => new { Id = line.Number, line.OrderId });

        builder.Property(line => line.Number)
            .IsRequired();

        builder.Property(line => line.OrderId)
            .IsRequired();

        builder.Property(line => line.ArticleId)
            .IsRequired();

        builder.OwnsOne(line => line.Quantity, owned =>
        {
            owned.Property(quantity => quantity.Value).HasColumnName("Quantity");
            owned.Property(quantity => quantity.Unit).HasColumnName("Unit");
        });

        builder.HasOne(line => line.Article)
            .WithMany();
    }
}
