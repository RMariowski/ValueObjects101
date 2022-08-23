using ValueObjects101.Domain.Shared.Enums;

namespace ValueObjects101.Presentation.Requests;

public record CreateSalesOrderRequest(CreateSalesOrderRequestLine[] Lines, string CustomerEmail, string CustomerNote);

public record CreateSalesOrderRequestLine(long ArticleId, double Quantity, Unit Unit);
