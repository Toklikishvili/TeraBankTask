namespace TeraBankTask.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public bool IsDelete { get; set; }
}