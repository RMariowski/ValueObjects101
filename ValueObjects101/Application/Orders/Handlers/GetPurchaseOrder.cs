using MediatR;
using Microsoft.EntityFrameworkCore;
using ValueObjects101.Application.Orders.Dto;
using ValueObjects101.Application.Orders.Exceptions;
using ValueObjects101.Infrastructure.Database;

namespace ValueObjects101.Application.Orders.Handlers;

public class GetPurchaseOrder
{
    public record Query(long Id) : IRequest<PurchaseOrderDto>;

    public class Handler : IRequestHandler<Query, PurchaseOrderDto>
    {
        private readonly DatabaseContext _dbContext;

        public Handler(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PurchaseOrderDto> Handle(Query query, CancellationToken cancellationToken)
        {
            var order = await _dbContext.PurchaseOrders
                .AsNoTracking()
                .Include(order => order.Lines)
                .ThenInclude(line => line.Article)
                .Where(order => order.Id == query.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (order is null)
                throw new PurchaseOrderNotFoundException(query.Id);

            return PurchaseOrderDto.From(order);
        }
    }
}
