using ValueObjects101.Domain.Articles;

namespace ValueObjects101.Domain.Orders;

public class SalesOrderLine
{
    public int Number { get; private set; }
    public long OrderId { get; private set; }
    public long ArticleId { get; private set; }
    public int Quantity { get; private set; }

    public Article Article { get; private set; } = null!;

    public SalesOrderLine(int number, long orderId, long articleId, int quantity)
    {
        Number = number;
        OrderId = orderId;
        ArticleId = articleId;
        Quantity = quantity;
    }

    private SalesOrderLine()
    {
    }
}
