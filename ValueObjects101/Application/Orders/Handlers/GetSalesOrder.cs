using MediatR;
using Microsoft.EntityFrameworkCore;
using ValueObjects101.Application.Orders.Dto;
using ValueObjects101.Application.Orders.Exceptions;
using ValueObjects101.Infrastructure.Database;

namespace ValueObjects101.Application.Orders.Handlers;

public class GetSalesOrder
{
    public record Query(long Id) : IRequest<SalesOrderDto>;

    public class Handler : IRequestHandler<Query, SalesOrderDto>
    {
        private readonly DatabaseContext _dbContext;

        public Handler(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SalesOrderDto> Handle(Query query, CancellationToken cancellationToken)
        {
            var order = await _dbContext.SalesOrders
                .AsNoTracking()
                .Include(order => order.Lines)
                .ThenInclude(line => line.Article)
                .Where(order => order.Id == query.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (order is null)
                throw new SalesOrderNotFoundException(query.Id);

            return SalesOrderDto.From(order);
        }
    }
}
