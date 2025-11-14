using MBH.Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBH.Exam.Infrastructure.Configurations;
public class ClientSessionConfiguration : IEntityTypeConfiguration<ClientSession>
{
    public void Configure(EntityTypeBuilder<ClientSession> builder)
    {
        builder.ToTable("ClientSessions");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.ClientId)
            .IsRequired();

        builder.Property(e => e.ClientName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.SessionDate)
            .IsRequired();

        builder.Property(e => e.SessionType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.ProviderName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Notes)
            .IsRequired(false)
            .HasMaxLength(1000);

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .IsRequired(false);

        builder.HasIndex(e => e.ClientId)
            .HasDatabaseName("IX_ClientSessions_ClientId");

        builder.HasIndex(e => e.ClientName)
            .HasDatabaseName("IX_ClientSessions_ClientName");

        builder.HasIndex(e => e.SessionDate)
            .HasDatabaseName("IX_ClientSessions_SessionDate");

        builder.HasIndex(e => new { e.ClientName, e.SessionDate })
            .HasDatabaseName("IX_ClientSessions_ClientName_SessionDate");

        builder.HasOne(e => e.Client)
            .WithMany(e => e.Sessions)
            .HasForeignKey(e => e.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
