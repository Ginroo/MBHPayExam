namespace MBH.Exam.Domain.Entities;

public class ClientSession : AuditableBaseEntity
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public string ClientName { get; set; } = string.Empty;

    public DateTime SessionDate { get; set; }

    public string SessionType { get; set; } = string.Empty;

    public string ProviderName { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public virtual Client? Client { get; set; }
}
