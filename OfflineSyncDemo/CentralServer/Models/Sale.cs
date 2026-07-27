namespace CentralServer.Models;

public class Sale
{
    public Guid Id { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; }
}