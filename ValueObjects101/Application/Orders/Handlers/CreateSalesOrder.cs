using MediatR;
using ValueObjects101.Domain.Orders;
using ValueObjects101.Domain.Shared.ValueObjects;
using ValueObjects101.Infrastructure.Database;

namespace ValueObjects101.Application.Orders.Handlers;

public class CreateSalesOrder
{
    public record Command(IEnumerable<Command.Line> Lines, Email CustomerEmail, string CustomerNote, Email CreatedBy)
        : IRequest<long>
    {
        public record Line(long ArticleId, Quantity Quantity);
    }

    public class Handler : IRequestHandler<Command, long>
    {
        private readonly DatabaseContext _dbContext;

        public Handler(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> Handle(Command command, CancellationToken cancellationToken)
        {
            SalesOrder order = new(command.CustomerEmail, command.CustomerNote, command.CreatedBy);

            await using (var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken))
            {
                _dbContext.SalesOrders.Add(order);
                await _dbContext.SaveChangesAsync(cancellationToken);

                var lines = command.Lines
                    .Select((line, index) => Map(line, index + 1, order.Id))
                    .ToArray();

                _dbContext.SalesOrderLines.AddRange(lines);
                await _dbContext.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }

            return order.Id;
        }

        private static SalesOrderLine Map(Command.Line line, int number, long orderId)
        {
            return new SalesOrderLine
            (
                number,
                orderId,
                line.ArticleId,
                line.Quantity
            );
        }
    }
}
