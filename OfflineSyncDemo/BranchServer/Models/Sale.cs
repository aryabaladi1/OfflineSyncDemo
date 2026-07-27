namespace BranchServer.Models
{
    public class Sale
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ProductName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
