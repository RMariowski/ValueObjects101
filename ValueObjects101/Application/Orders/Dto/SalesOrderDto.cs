using ValueObjects101.Domain.Orders;

namespace ValueObjects101.Application.Orders.Dto;

public record SalesOrderDto
(
    long Id,
    IEnumerable<OrderLineDto> Lines,
    string CustomerEmail,
    string CustomerNote,
    DateTime CreatedAt,
    string CreatedBy)
{
    public static SalesOrderDto From(SalesOrder order)
    {
        return new SalesOrderDto
        (
            order.Id,
            order.Lines.Select(OrderLineDto.From),
            order.CustomerEmail,
            order.CustomerNote,
            order.CreatedAt,
            order.CreatedBy
        );
    }
}
