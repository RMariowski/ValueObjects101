using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValueObjects101.Domain.Orders;

namespace ValueObjects101.Infrastructure.Database.EntityTypeConfigurations;

public class PurchaseOrderLineEntityTypeConfiguration : IEntityTypeConfiguration<PurchaseOrderLine>
{
    public void Configure(EntityTypeBuilder<PurchaseOrderLine> builder)
    {
        builder.HasKey(line => new { Id = line.Number, line.OrderId });

        builder.Property(line => line.Number)
            .IsRequired();

        builder.Property(line => line.OrderId)
            .IsRequired();

        builder.Property(line => line.ArticleId)
            .IsRequired();

        builder.Property(line => line.Quantity)
            .IsRequired();

        builder.Property(line => line.Unit)
            .IsRequired();

        builder.HasOne(line => line.Article)
            .WithMany();
    }
}
