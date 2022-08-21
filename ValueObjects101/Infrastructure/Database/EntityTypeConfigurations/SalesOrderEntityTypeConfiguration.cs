using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValueObjects101.Domain.Orders;

namespace ValueObjects101.Infrastructure.Database.EntityTypeConfigurations;

public class SalesOrderEntityTypeConfiguration : IEntityTypeConfiguration<SalesOrder>
{
    public void Configure(EntityTypeBuilder<SalesOrder> builder)
    {
        builder.HasKey(order => order.Id);
        builder.Property(order => order.Id)
            .IsRequired();

        builder.Property(order => order.CreatedAt)
            .IsRequired();
        
        builder.HasMany(order => order.Lines)
            .WithOne()
            .HasForeignKey(nameof(SalesOrderLine.OrderId));
    }
}