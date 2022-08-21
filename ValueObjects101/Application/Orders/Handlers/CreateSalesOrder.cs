using MediatR;
using ValueObjects101.Application.Orders.Exceptions;
using ValueObjects101.Application.Shared.Validators;
using ValueObjects101.Domain.Orders;
using ValueObjects101.Infrastructure.Database;

namespace ValueObjects101.Application.Orders.Handlers;

public class CreateSalesOrder
{
    public record Command(IEnumerable<Command.Line> Lines, string ContactEmail, string CreatedBy) : IRequest<long>
    {
        public record Line(long ArticleId, int Quantity);
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
            EmailValidator.ThrowIfInvalid(command.ContactEmail);

            SalesOrder order = new(command.ContactEmail, command.CreatedBy);

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
            if (line.Quantity <= 0)
                throw new InvalidQuantityException(line.Quantity);

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
