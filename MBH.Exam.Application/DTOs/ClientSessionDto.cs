using MBH.Exam.Domain.Entities;

namespace MBH.Exam.Application.DTOs;

public class ClientSessionDto
{
    public int Id { get; set; }

    public string ClientName { get; set; } = string.Empty;

    public DateTime SessionDate { get; set; }

    public string SessionType { get; set; } = string.Empty;

    public string ProviderName { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public static ClientSessionDto Map(ClientSession session)
    {
        return new ClientSessionDto
        {
            Id = session.Id,
            ClientName = session.ClientName,
            SessionDate = session.SessionDate,
            SessionType = session.SessionType,
            ProviderName = session.ProviderName,
            Notes = session.Notes,
            CreatedAt = session.CreatedAt,
            UpdatedAt = session.UpdatedAt
        };
    }


}
