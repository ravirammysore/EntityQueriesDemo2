﻿public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }

    public List<Order> Orders { get; set; } = new List<Order>();
}