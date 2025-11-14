namespace MBH.Exam.Domain.Entities;

public abstract class AuditableBaseEntity
{
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
