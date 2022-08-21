namespace ValueObjects101.Presentation.Requests;

public record CreateSalesOrderRequest(CreateSalesOrderRequestLine[] Lines, string ContactEmail);

public record CreateSalesOrderRequestLine(long ArticleId, int Quantity);
