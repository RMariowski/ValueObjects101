using MediatR;
using ValueObjects101.Application.Shared.Exceptions;
using ValueObjects101.Application.Shared.Validators;
using ValueObjects101.Domain.Orders;
using ValueObjects101.Infrastructure.Database;

namespace ValueObjects101.Application.Orders.Handlers;

public class CreatePurchaseOrder
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
            if (!EmailValidator.IsValid(request.ContactEmail))
                throw new InvalidEmailException(request.ContactEmail);

            PurchaseOrder order = new(request.ContactEmail, request.CreatedBy);

            _dbContext.PurchaseOrders.Add(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
