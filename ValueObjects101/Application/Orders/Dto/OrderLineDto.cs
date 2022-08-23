using ValueObjects101.Domain.Orders;
using ValueObjects101.Domain.Shared.Enums;

namespace ValueObjects101.Application.Orders.Dto;

public record OrderLineDto(int Number, string Text, double Quantity, Unit Unit)
{
    public static OrderLineDto From(PurchaseOrderLine line)
    {
        return new OrderLineDto(line.Number, line.Article.Text, line.Quantity.Value, line.Quantity.Unit);
    }

    public static OrderLineDto From(SalesOrderLine line)
    {
        return new OrderLineDto(line.Number, line.Article.Text, line.Quantity.Value, line.Quantity.Unit);
    }
}
