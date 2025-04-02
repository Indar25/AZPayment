namespace Payment_Core.Domain;

public class Payment
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public DateTime PaidAt { get; set; } = DateTime.UtcNow;
}

