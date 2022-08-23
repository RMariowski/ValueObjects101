using Microsoft.EntityFrameworkCore;
using ValueObjects101.Domain.Articles;
using ValueObjects101.Domain.Orders;
using ValueObjects101.Domain.Shared.ValueObjects;
using ValueObjects101.Infrastructure.Database.Converters;
using ValueObjects101.Infrastructure.Database.EntityTypeConfigurations;

namespace ValueObjects101.Infrastructure.Database;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Article> Articles => Set<Article>();
    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    public DbSet<PurchaseOrderLine> PurchaseOrderLines => Set<PurchaseOrderLine>();
    public DbSet<SalesOrder> SalesOrders => Set<SalesOrder>();
    public DbSet<SalesOrderLine> SalesOrderLines => Set<SalesOrderLine>();

    public DatabaseContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(_configuration.GetConnectionString("Database"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleEntityTypeConfiguration).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Email>().HaveConversion<EmailConverter>();
        // NOTE: Conversion of multiple column is planned for EF 8
        // configurationBuilder.Properties<Quantity>().HaveConversion<QuantityConverter>();
    }
}
