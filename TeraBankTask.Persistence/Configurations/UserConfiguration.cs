using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeraBankTask.Domain.Entities;

namespace TeraBankTask.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Firstname).HasMaxLength(50);
        builder.Property(u => u.Lastname).HasMaxLength(50);
        builder.Property(u => u.Email).HasMaxLength(100);
        builder.Property(u => u.Password).HasMaxLength(100);

        builder.HasMany(u => u.TransactionsSent)
               .WithOne(t => t.SenderUser)
               .HasForeignKey(t => t.SenderUserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.TransactionsReceived)
               .WithOne(t => t.ReciveUser)
               .HasForeignKey(t => t.ReceiverUserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}