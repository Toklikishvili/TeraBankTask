namespace TeraBankTask.Domain.Entities;

public class User : BaseEntity
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public virtual ICollection<Transaction> TransactionsSent { get; set; } = new List<Transaction>();
    public virtual ICollection<Transaction> TransactionsReceived { get; set; } = new List<Transaction>();
}