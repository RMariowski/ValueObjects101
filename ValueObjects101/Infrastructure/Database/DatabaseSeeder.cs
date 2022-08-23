using ValueObjects101.Domain.Articles;
using ValueObjects101.Domain.Orders;
using ValueObjects101.Domain.Shared.Enums;
using ValueObjects101.Domain.Shared.ValueObjects;

namespace ValueObjects101.Infrastructure.Database;

public static class DatabaseSeeder
{
    public static async Task Seed(DatabaseContext db)
    {
        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();

        Article article1 = new("Phone");
        Article article2 = new("Notebook");
        Article article3 = new("Phone Charger");
        Article article4 = new("Notebook Charger");
        Article article5 = new("Water");

        db.Articles.AddRange(article1, article2, article3, article4, article5);
        await db.SaveChangesAsync();

        PurchaseOrder purchaseOrder1 = new(new Email("contact1@email.com"), new Email("abc@abc.com"));
        PurchaseOrder purchaseOrder2 = new(new Email("contact2@email.com"), new Email("xyz@xyz.net"));
        PurchaseOrder purchaseOrder3 = new(new Email("contact3@email.com"), new Email("wtf@wtf.wtf"));

        db.PurchaseOrders.AddRange(purchaseOrder1, purchaseOrder2, purchaseOrder3);
        await db.SaveChangesAsync();

        db.PurchaseOrderLines.AddRange
        (
            new PurchaseOrderLine(1, purchaseOrder1.Id, article1.Id, new Quantity(3), Unit.Pieces),
            new PurchaseOrderLine(2, purchaseOrder1.Id, article2.Id, new Quantity(2), Unit.Pieces),
            new PurchaseOrderLine(3, purchaseOrder1.Id, article3.Id, new Quantity(1), Unit.Pieces),
            new PurchaseOrderLine(1, purchaseOrder2.Id, article1.Id, new Quantity(420), Unit.Pieces),
            new PurchaseOrderLine(2, purchaseOrder2.Id, article5.Id, new Quantity(2.5), Unit.Liters)
        );
        await db.SaveChangesAsync();

        SalesOrder salesOrder1 = new(new Email("customer1@email.com"), "Note #1", new Email("abc@abc.com"));
        SalesOrder salesOrder2 = new(new Email("customer2@email.com"), "Note #2", new Email("xyz@xyz.net"));
        SalesOrder salesOrder3 = new(new Email("customer3@email.com"), "Note #3", new Email("wtf@wtf.wtf"));

        db.SalesOrders.AddRange(salesOrder1, salesOrder2, salesOrder3);
        await db.SaveChangesAsync();

        db.SalesOrderLines.AddRange
        (
            new SalesOrderLine(1, salesOrder1.Id, article1.Id, new Quantity(3), Unit.Pieces),
            new SalesOrderLine(2, salesOrder1.Id, article2.Id, new Quantity(2), Unit.Pieces),
            new SalesOrderLine(3, salesOrder1.Id, article3.Id, new Quantity(1), Unit.Pieces),
            new SalesOrderLine(4, salesOrder2.Id, article4.Id, new Quantity(420), Unit.Pieces)
        );
        await db.SaveChangesAsync();
    }
}
