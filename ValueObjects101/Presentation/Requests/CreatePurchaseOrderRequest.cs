namespace ValueObjects101.Presentation.Requests;

public record CreatePurchaseOrderRequest(CreatePurchaseOrderRequestLine[] Lines, string ContactEmail);

public record CreatePurchaseOrderRequestLine(long ArticleId, int Quantity);
