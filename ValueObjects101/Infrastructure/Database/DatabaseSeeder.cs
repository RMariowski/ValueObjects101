using ValueObjects101.Domain.Articles;
using ValueObjects101.Domain.Orders;

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

        db.Articles.AddRange(article1, article2, article3, article4);
        await db.SaveChangesAsync();

        PurchaseOrder purchaseOrder1 = new("contact1@email.com", "abc@abc.com");
        PurchaseOrder purchaseOrder2 = new("contact2@email.com", "xyz@xyz.net");
        PurchaseOrder purchaseOrder3 = new("contact3@email.com", "wtf@wtf.wtf");

        db.PurchaseOrders.AddRange(purchaseOrder1, purchaseOrder2, purchaseOrder3);
        await db.SaveChangesAsync();

        db.PurchaseOrderLines.AddRange
        (
            new PurchaseOrderLine(1, purchaseOrder1.Id, article1.Id, 3),
            new PurchaseOrderLine(2, purchaseOrder1.Id, article2.Id, 2),
            new PurchaseOrderLine(3, purchaseOrder1.Id, article3.Id, 1),
            new PurchaseOrderLine(1, purchaseOrder2.Id, article1.Id, 420)
        );
        await db.SaveChangesAsync();

        SalesOrder salesOrder1 = new("contact1@email.com", "abc@abc.com");
        SalesOrder salesOrder2 = new("contact2@email.com", "xyz@xyz.net");
        SalesOrder salesOrder3 = new("contact3@email.com", "wtf@wtf.wtf");

        db.SalesOrders.AddRange(salesOrder1, salesOrder2, salesOrder3);
        await db.SaveChangesAsync();

        db.SalesOrderLines.AddRange
        (
            new SalesOrderLine(salesOrder1.Id, article1, 3),
            new SalesOrderLine(salesOrder1.Id, article2, 2),
            new SalesOrderLine(salesOrder1.Id, article3, 1),
            new SalesOrderLine(salesOrder2.Id, article4, 420)
        );
        await db.SaveChangesAsync();
    }
}
