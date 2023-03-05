public class DbInitializer
{
    public static void Seed(MyDbContext context)
    {
        // Seed customers
        var customers = new List<Customer>
        {
            new Customer { Name = "Alice", Age = 25, City = "New York" },
            new Customer { Name = "Bob", Age = 30, City = "Los Angeles" },
            new Customer { Name = "Charlie", Age = 35, City = "Chicago" }
        };
        context.Customers.AddRange(customers);
        context.SaveChanges();

        // Seed categories
        var categories = new List<Category>
        {
            new Category { Name = "Electronics" },
            new Category { Name = "Clothing" },
            new Category { Name = "Furniture" }
        };
        context.Categories.AddRange(categories);
        context.SaveChanges();

        // Seed products
        var products = new List<Product>
        {
            new Product { Name = "Smartphone", UnitPrice = 500, StockQuantity = 100, CategoryId = 1 },
            new Product { Name = "T-Shirt", UnitPrice = 20, StockQuantity = 200, CategoryId = 2 },
            new Product { Name = "Sofa", UnitPrice = 1000, StockQuantity = 50, CategoryId = 3 }
        };
        context.Products.AddRange(products);
        context.SaveChanges();

        // Seed orders and their details 
        var orders = new List<Order>
        {
            new Order 
            { 
                CustomerId = 1, OrderedDate = new DateTime(2022, 12, 31, 10, 30, 00), OrderProducts = new List<Detail> 
                { 
                    new Detail { ProductId = 1, Quantity = 2 } 
                } 
            },
            new Order 
            { 
                CustomerId = 2, OrderedDate = new DateTime(2023, 1, 15, 11, 40, 00), OrderProducts = new List<Detail>
                { 
                    new Detail { ProductId = 2, Quantity = 3 } 
                } 
            },
            new Order {
                CustomerId = 3, OrderedDate = new DateTime(2023, 2, 28, 09, 20, 00), OrderProducts = new List<Detail> 
                { 
                    new Detail { ProductId = 3, Quantity = 1 } 
                } 
            }
        };
        context.Orders.AddRange(orders);
        context.SaveChanges();
    }
}
