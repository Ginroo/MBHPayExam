namespace MBH.Exam.Domain.Entities;

public class Client : AuditableBaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<ClientSession> Sessions { get; set; } = [];
}
