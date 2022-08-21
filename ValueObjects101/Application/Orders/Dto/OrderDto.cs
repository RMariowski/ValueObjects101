using ValueObjects101.Domain.Orders;

namespace ValueObjects101.Application.Orders.Dto;

public record OrderDto(long Id, IEnumerable<OrderLineDto> Lines, DateTime CreatedAt, string CreatedBy)
{
    public static OrderDto From(PurchaseOrder order)
    {
        return new OrderDto
        (
            order.Id,
            order.Lines.Select(OrderLineDto.From),
            order.CreatedAt,
            order.CreatedBy
        );
    }

    public static OrderDto From(SalesOrder order)
    {
        return new OrderDto
        (
            order.Id,
            order.Lines.Select(OrderLineDto.From),
            order.CreatedAt,
            order.CreatedBy
        );
    }
}
