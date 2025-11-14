using MBH.Exam.Application.DTOs;

namespace MBH.Exam.Application.Interfaces;

public interface IClientSessionService
{
    Task<ClientSessionDto> CreateSessionAsync(CreateClientSessionDto dto);
    Task<IEnumerable<ClientSessionDto>> GetAllSessionsAsync();
    Task<ClientSessionDto?> GetSessionByIdAsync(int id);
    Task<IEnumerable<ClientSessionDto>> GetSessionsByClientNameAsync(string clientName);
    Task<ClientSessionDto> UpdateSessionAsync(int id, UpdateClientSessionDto dto);
    Task<bool> DeleteSessionAsync(int id);
}
