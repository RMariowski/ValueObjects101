﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValueObjects101.Domain.Orders;

namespace ValueObjects101.Infrastructure.Database.EntityTypeConfigurations;

public class PurchaseOrderLineEntityTypeConfiguration : IEntityTypeConfiguration<PurchaseOrderLine>
{
    public void Configure(EntityTypeBuilder<PurchaseOrderLine> builder)
    {
        builder.HasKey(line => line.Id);
        builder.Property(line => line.Id)
            .IsRequired();

        builder.Property(line => line.Quantity)
            .IsRequired();

        builder.HasOne(line => line.Article)
            .WithMany();
    }
}
