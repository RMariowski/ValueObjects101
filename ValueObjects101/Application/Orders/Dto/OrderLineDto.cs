using ValueObjects101.Domain.Orders;

namespace ValueObjects101.Application.Orders.Dto;

public record OrderLineDto(int Number, string Text, int Quantity)
{
    public static OrderLineDto From(PurchaseOrderLine line)
    {
        return new OrderLineDto(line.Number, line.Article.Text, line.Quantity.Value);
    }

    public static OrderLineDto From(SalesOrderLine line)
    {
        return new OrderLineDto(line.Number, line.Article.Text, line.Quantity.Value);
    }
}
