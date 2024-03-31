namespace TeraBankTask.Domain.Entities;

public class Transaction : BaseEntity
{
    public decimal Amount { get; set; }
    public DateTime CreateDate { get; set; }

    public int SenderUserId { get; set; }
    public virtual User? SenderUser { get; set; }
    public int ReceiverUserId { get; set; }
    public virtual User? ReciveUser { get; set; }
}