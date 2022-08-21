using MediatR;
using ValueObjects101.Application.Shared.Validators;
using ValueObjects101.Domain.Orders;
using ValueObjects101.Infrastructure.Database;

namespace ValueObjects101.Application.Orders.Handlers;

public class CreateSalesOrder
{
    public record Command(string ContactEmail, string CreatedBy) : IRequest<long>;

    public class Handler : IRequestHandler<Command, long>
    {
        private readonly DatabaseContext _dbContext;

        public Handler(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> Handle(Command request, CancellationToken cancellationToken)
        {
            EmailValidator.ThrowIfInvalid(request.ContactEmail);

            SalesOrder order = new(request.ContactEmail, request.CreatedBy);

            _dbContext.SalesOrders.Add(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
