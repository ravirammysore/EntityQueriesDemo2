using Microsoft.EntityFrameworkCore;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Linq to multiple entities demo !");

        MyDbContext context = new MyDbContext();

        try
        {
            Console.WriteLine("Preparing database...");
            context.Database.Migrate();

            //Should be used only during testing!
            if (!context.Customers.Any())
            {
                Console.WriteLine("Starting to seed data...");
                // Seed database with initial data
                DbInitializer.Seed(context);
                Console.WriteLine("seed data completed!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Quitting the application now.");
            Console.ReadKey();
            return;
        }

        //Get all products in a specific category:
        var categoryId = 1;
        var products = context.Products.Where(p => p.CategoryId == categoryId).ToList();
        //todo: try looping through and printing them 

        //Get all orders for a specific customer:
        var customerId = 1;
        var orders = context.Orders.Where(o => o.CustomerId == customerId).ToList();
        //todo: try looping through and printing them 

        //Get the average age of all customers:
        var avgAge = context.Customers.Average(c => c.Age);
        Console.WriteLine("Average age of all customers: "+ avgAge);

        //Get the top 10 products with the highest unit price:
        var topProducts = context.Products.OrderByDescending(p => p.UnitPrice).Take(10).ToList();
        //todo: try looping through and printing them 

        //find out on what day did the customer named Alice purchase a smartphone, if any?
        var orderDate = context.Orders
            .Where(o => o.Customer.Name == "Alice" &&
                        o.OrderProducts.Any(op => op.Product.Name == "Smartphone"))
            .Select(o => o.OrderedDate)
            .FirstOrDefault();

        Console.WriteLine("The day when Alice ordered a smartphone: " + orderDate);

        Console.ReadKey();
    }
}