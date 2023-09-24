namespace Customer.Api.Customers;

public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public bool? IsActive { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}