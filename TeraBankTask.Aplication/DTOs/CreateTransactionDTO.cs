namespace TeraBankTask.Aplication.DTOs;

public class CreateTransactionDTO
{
    public decimal Amount { get; set; }
    public int SenderUserId { get; set; }
    public int ReceiverUserId { get; set; }
}
