public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public DateTime OrderedDate { get; set; } // new property for ordered date
    public List<Detail> OrderProducts { get; set; }
}
