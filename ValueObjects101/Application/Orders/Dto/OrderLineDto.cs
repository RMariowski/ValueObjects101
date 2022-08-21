using ValueObjects101.Domain.Orders;

namespace ValueObjects101.Application.Orders.Dto;

public record OrderLineDto(int Id, string Text, int Quantity)
{
    public static OrderLineDto From(PurchaseOrderLine line)
    {
        return new OrderLineDto(line.Id, line.Article.Text, line.Quantity);
    }

    public static OrderLineDto From(SalesOrderLine line)
    {
        return new OrderLineDto(line.Id, line.Article.Text, line.Quantity);
    }
}
