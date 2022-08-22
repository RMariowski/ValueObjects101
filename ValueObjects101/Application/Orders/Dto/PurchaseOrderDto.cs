using ValueObjects101.Domain.Orders;

namespace ValueObjects101.Application.Orders.Dto;

public record PurchaseOrderDto
(
    long Id,
    IEnumerable<OrderLineDto> Lines,
    string ContactEmail,
    DateTime CreatedAt,
    string CreatedBy)
{
    public static PurchaseOrderDto From(PurchaseOrder order)
    {
        return new PurchaseOrderDto
        (
            order.Id,
            order.Lines.Select(OrderLineDto.From),
            order.ContactEmail,
            order.CreatedAt,
            order.CreatedBy
        );
    }
}
