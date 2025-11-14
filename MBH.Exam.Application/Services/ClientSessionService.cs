using MBH.Exam.Application.DTOs;
using MBH.Exam.Application.Interfaces;
using MBH.Exam.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace MBH.Exam.Application.Services;

public class ClientSessionService(
    IUnitOfWork unitOfWork,
    IClientRepository clientRepository,
    IClientSessionRepository sessionRepository,
    ILogger<ClientSessionService> logger) : IClientSessionService
{
    public async Task<ClientSessionDto> CreateSessionAsync(CreateClientSessionDto dto)
    {
        if (dto is null)
        {
            logger.LogWarning("CreateSessionAsync called with null dto");
            throw new ArgumentNullException(nameof(dto), "Session data cannot be null");
        }

        try
        {
            logger.LogInformation("Creating session for client: {ClientName}", dto.ClientName);

            var client = await clientRepository.GetByNameAsync(dto.ClientName);
            
            if (client is null)
            {
                logger.LogInformation("Client {ClientName} not found, creating new client", dto.ClientName);

                client = new Client
                {
                    Name = dto.ClientName,
                    CreatedAt = DateTime.UtcNow
                };

                client = await clientRepository.AddAsync(client);
                logger.LogInformation("Created new client {ClientId} with name {ClientName}", client.Id, dto.ClientName);
            }

            var session = new ClientSession
            {
                ClientId = client.Id,
                ClientName = dto.ClientName,
                SessionDate = dto.SessionDate,
                SessionType = dto.SessionType,
                ProviderName = dto.ProviderName,
                Notes = dto.Notes,
                CreatedAt = DateTime.UtcNow
            };

            client.Sessions.Add(session);

            await unitOfWork.SaveChangesAsync();

            logger.LogInformation(
                "Successfully created for client {ClientName}",
                dto.ClientName);

            return ClientSessionDto.Map(session);
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "Error creating session for client {ClientName}: {ErrorMessage}",
                dto.ClientName,
                ex.Message);

            throw;
        }
    }

    public async Task<IEnumerable<ClientSessionDto>> GetAllSessionsAsync()
    {
        try
        {
            logger.LogInformation("Retrieving all sessions");
            var sessions = await sessionRepository.GetAllAsync();
            logger.LogInformation("Retrieved {Count} sessions", sessions.Count());
            return sessions.Select(ClientSessionDto.Map);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving all sessions");
            throw;
        }
    }

    public async Task<ClientSessionDto?> GetSessionByIdAsync(int id)
    {
        try
        {
            logger.LogInformation("Retrieving session with ID {SessionId}", id);
            var session = await sessionRepository.GetByIdAsync(id);

            if (session == null)
            {
                logger.LogWarning("Session with ID {SessionId} not found", id);
            }

            return session != null ? ClientSessionDto.Map(session) : null;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving session with ID {SessionId}", id);
            throw;
        }
    }

    public async Task<IEnumerable<ClientSessionDto>> GetSessionsByClientNameAsync(string clientName)
    {
        if (string.IsNullOrWhiteSpace(clientName))
        {
            logger.LogWarning("GetSessionsByClientNameAsync called with empty client name");
            throw new ArgumentException("Client name cannot be null or empty", nameof(clientName));
        }

        try
        {
            logger.LogInformation("Retrieving sessions for client: {ClientName}", clientName);
            var sessions = await sessionRepository.GetSessionsByClientNameAsync(clientName);
            logger.LogInformation(
                "Retrieved {Count} sessions for client {ClientName}",
                sessions.Count(),
                clientName);

            return sessions.Select(ClientSessionDto.Map);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving sessions for client {ClientName}", clientName);
            throw;
        }
    }

    public async Task<ClientSessionDto> UpdateSessionAsync(int id, UpdateClientSessionDto dto)
    {
        if (dto == null)
        {
            logger.LogWarning("UpdateSessionAsync called with null dto for session {SessionId}", id);
            throw new ArgumentNullException(nameof(dto), "Update data cannot be null");
        }

        try
        {
            logger.LogInformation("Updating session {SessionId}", id);

            var session = await sessionRepository.GetByIdAsync(id);
            if (session == null)
            {
                logger.LogWarning("Session {SessionId} not found for update", id);
                throw new KeyNotFoundException($"Session with ID {id} not found");
            }

            session.ClientName = dto.ClientName;
            session.SessionDate = dto.SessionDate;
            session.SessionType = dto.SessionType;
            session.ProviderName = dto.ProviderName;
            session.Notes = dto.Notes;
            session.UpdatedAt = DateTime.UtcNow;

            sessionRepository.Update(session);
            await unitOfWork.SaveChangesAsync();

            logger.LogInformation("Successfully updated session {SessionId}", id);

            return ClientSessionDto.Map(session);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating session {SessionId}", id);
            throw;
        }
    }

    public async Task<bool> DeleteSessionAsync(int id)
    {
        try
        {
            logger.LogInformation("Deleting session {SessionId}", id);

            var session = await sessionRepository.GetByIdAsync(id);
            if (session == null)
            {
                logger.LogWarning("Session {SessionId} not found for deletion", id);
                return false;
            }

            sessionRepository.Delete(session);
            await unitOfWork.SaveChangesAsync();

            logger.LogInformation("Successfully deleted session {SessionId}", id);

            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting session {SessionId}", id);
            throw;
        }
    }
}
