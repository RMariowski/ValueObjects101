namespace ValueObjects101.Presentation.Requests;

public record CreateSalesOrderRequest(CreateSalesOrderRequestLine[] Lines, string ContactEmail, string CustomerNote);

public record CreateSalesOrderRequestLine(long ArticleId, int Quantity);
